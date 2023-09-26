using WeddingDay.Service.DTOs.ClientDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface IClientService
    {
        public Task<ClientForResultDto> CreateAsync(ClientForCreationDto dto);
        public Task<ClientForResultDto> UpdateAsync(ClientForUpdateDto dto);
        public Task<bool> DeleteAsync(long id);
        public Task<ClientForResultDto> GetByIdAsync(long id);
        public Task<List<ClientForResultDto>> GetAllAsync();
    }
}
