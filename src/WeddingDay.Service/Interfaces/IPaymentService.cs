using WeddingDay.Service.DTOs.PaymentDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface IPaymentService
    {
        public Task<PaymentForResultDto> CreateAsync(PaymentForCreationDto  dto);
        public Task<PaymentForResultDto> UpdateAsync(PaymentForUpdateDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<PaymentForResultDto> GetByIdAsync(long id);
        public Task<List<PaymentForResultDto>> GetAllAsync();
    }
}
