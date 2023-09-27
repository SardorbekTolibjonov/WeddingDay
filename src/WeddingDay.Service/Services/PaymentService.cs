using WeddingDay.Domain.Entities;
using WeddingDay.Data.Repositories;
using WeddingDay.Service.Exceptions;
using WeddingDay.Service.Interfaces;
using WeddingDay.Service.DTOs.PaymentDtos;
using WeddingDay.Data.IRepositories;

namespace WeddingDay.Service.Services
{
    public class PaymentService : IPaymentService
    { 
        private long _id;
        Repository<Payment> paymentRepository = new Repository<Payment>();
        public async Task<PaymentForResultDto> CreateAsync(PaymentForCreationDto dto)
        {
            await GenerateIdAsync();

            var payment = (await this.paymentRepository.SelectAllAsync()).FirstOrDefault(p => p.Amount == dto.Amount);
            if (payment is not null)
                throw new CustomException(400, "Payment is already exist");
            var mapped = new Payment()
            {
                Id = _id,
                Amount = dto.Amount,
                Phone = dto.Phone,
            };

            await this.paymentRepository.InsertAsync(mapped);
            var result = new PaymentForResultDto()
            {
                Id = _id,
                Amount = dto.Amount,
                Phone = dto.Phone
            };
            
            
            return result;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var result = await this.paymentRepository.SelectByIdAsync(id);
            if (result is null)
                throw new CustomException(404, "Payment is not found");

            return await this.paymentRepository.DeleteAsync(id);
        }

        public async Task<List<PaymentForResultDto>> GetAllAsync()
        {

            var payments = await this.paymentRepository.SelectAllAsync();
            var result = new List<PaymentForResultDto>();
            foreach (var payment in payments)
            {
                var mapped = new PaymentForResultDto()
                {
                    Id= payment.Id,
                    Amount = payment.Amount,
                    Phone= payment.Phone,
                };
                result.Add(mapped);
            }

            return result;
        }

        public async Task<PaymentForResultDto> GetByIdAsync(long id)
        {
            var payment = await this.paymentRepository.SelectByIdAsync(id);
            if (payment is null)
                throw new CustomException(404, "Pyment is not found");

            var result = new PaymentForResultDto()
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Phone = payment.Phone,
            };

            return result;
        }

        public async Task<PaymentForResultDto> UpdateAsync(PaymentForUpdateDto dto)
        {
            var payment = await this.paymentRepository.SelectByIdAsync(dto.Id);
            if (payment is null)
                throw new CustomException(404, "Payment is not found");

            var mapped = new Payment()
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Phone = dto.Phone,
                UpdatedAt = DateTime.UtcNow,
            };

            await this.paymentRepository.UpdateAsync(mapped);

            var result = new PaymentForResultDto()
            {
                 Id = dto.Id,
                 Amount = dto.Amount,
                 Phone = dto.Phone,
            };
            return result;
        }
        public async Task GenerateIdAsync()
        {
            var result = await this.paymentRepository.SelectAllAsync();
            if (result.Count == 0)
                _id = 1;
            else
            {
                var res = result[result.Count - 1];
                _id = ++res.Id;
            }
        }
    }
}
