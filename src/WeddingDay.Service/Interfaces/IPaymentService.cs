using WeddingDay.Service.DTOs.PaymentDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface IPaymentService
    {
        public Task<PaymentForResultDto> CreateAsync(PaymentForResultDto dto);
        public Task<PaymentForResultDto> UpdateAsync(PaymentForResultDto dto);
        public Task<bool> DeleteAsync(long id);
        public Task<PaymentForResultDto> GetByIdAsync(long id);
        public Task<List<PaymentForResultDto>> GetAllAsync();
    }
}
