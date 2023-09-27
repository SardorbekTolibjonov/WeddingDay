using WeddingDay.Service.DTOs.SingerDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface ISingerService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<SingerForResultDto> GetByIdAsync(long id);
        public Task<List<SingerForResultDto>> GetAllAsync();
    }
}

