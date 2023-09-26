using WeddingDay.Service.DTOs.WeddingDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface IWeddingService
    {
        public Task<WeddingForResultDto> CreateAsync(WeddingForCreationDto dto);
        public Task<WeddingForResultDto> UpdateAsync(WeddingForUpdateDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<WeddingForResultDto> GetByIdAsync(long id);
        public Task<List<WeddingForResultDto>> GetAllAsync();

    }
}
