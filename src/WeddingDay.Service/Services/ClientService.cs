using WeddingDay.Data.IRepositories;
using WeddingDay.Data.Repositories;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.ClientDtos;
using WeddingDay.Service.Exceptions;
using WeddingDay.Service.Interfaces;

namespace WeddingDay.Service.Services
{
    public class ClientService : IClientService
    {
        private long _id;
        private readonly IRepository<Client> clientRepository = new Repository<Client>();


        public async Task<ClientForResultDto> CreateAsync(ClientForCreationDto dto)
        {
            var client = (await clientRepository.SelectAllAsync()).FirstOrDefault(c => c.Phone.ToLower() ==  dto.Phone.ToLower();
            if (client is not null) 
                throw new CustomException(400, "Client is already exsist");

            var person = new Client()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow
            };

            var result = await clientRepository.InsertAsync(person);

            var mappedClient = new ClientForResultDto()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Phone = result.Phone
            };

            return mappedClient;
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClientForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientForResultDto> UpdateAsync(ClientForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public async long GetIdAsync()
        {
            var client = await clientRepository.SelectAllAsync().t;
        }
    }
}
