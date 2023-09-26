using WeddingDay.Service.DTOs.ClientDtos;

namespace WeddingDay.Service.Interfaces
{
    public interface IClientService
    {
        public Task<ClientForResultDto> CreateAsync(ClientForResultDto dto);
        public Task<ClientForResultDto> UpdateAsync(ClientForResultDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<ClientForResultDto> GetByIdAsync(long id);
        public Task<List<ClientForResultDto>> GetAllAsync();
    }
}
