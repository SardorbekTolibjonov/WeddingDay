using WeddingDay.Service.DTOs.PaymentDtos;
using WeddingDay.Service.Interfaces;

namespace WeddingDay.Service.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<PaymentForResultDto> CreateAsync(PaymentForResultDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentForResultDto> UpdateAsync(PaymentForResultDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
