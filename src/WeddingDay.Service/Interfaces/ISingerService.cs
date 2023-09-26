using WeddingDay.Service.DTOs.SingerDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface ISingerService
    {
        public Task<SingerForResultDto> CreateAsync(SingerForResultDto dto);
        public Task<SingerForResultDto> UpdateAsync(SingerForResultDto dto);
        public Task<bool> DeleteAsync(long id);
        public Task<SingerForResultDto> GetByIdAsync(long id);
        public Task<List<SingerForResultDto>> GetAllAsync();
    }
}
