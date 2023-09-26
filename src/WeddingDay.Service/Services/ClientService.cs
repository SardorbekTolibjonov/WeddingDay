using WeddingDay.Data.Repositories;
using WeddingDay.Service.Interfaces;
using WeddingDay.Service.DTOs.ClientDtos;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.Exceptions;

namespace WeddingDay.Service.Services
{
 
    public class ClientService : IClientService
    {
        private long _id;
        Repository<Client> clientRepository = new Repository<Client>();

        public async Task<ClientForResultDto> CreateAsync(ClientForResultDto dto)
        {
            var client = (await this.clientRepository.SelectAllAsync()).FirstOrDefault(c => c.Phone.ToLower() == dto.Phone.ToLower());
            if (client is not null)
                throw new CustomException(404, "Client is already exsit");
            var mapped = new Client()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow
            };

            await clientRepository.InsertAsync(mapped);

            var result = new ClientForResultDto()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
            };
            return result;
        }

        public async Task<List<ClientForResultDto>> GetAllAsync()
        {
            var clients = await this.clientRepository.SelectAllAsync();
            var result = new List<ClientForResultDto>();

            foreach (var client in clients)
            {
                var mapped = new ClientForResultDto()
                {
                    Id= client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Phone = client.Phone,
                };
                result.Add(mapped);
            }
            return result;
        }

        public async Task<ClientForResultDto> GetByIdAsync(long id)
        {
            var client = await this.clientRepository.SelectByIdAsync(id);
            if (client is null)
                throw new CustomException(404, "Client is not found");

            var mapped = new ClientForResultDto()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
            };
            return mapped;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var client = await this.clientRepository.SelectByIdAsync(id);

            if (client is null)
                throw new CustomException(404, "Client is not found");
            return await this.clientRepository.DeleteAsync(id);
        }

        public async Task<ClientForResultDto> UpdateAsync(ClientForResultDto dto)
        {
            var client = await this.clientRepository.SelectByIdAsync(dto.Id);
            if (client is null)
                throw new CustomException(404, "Client is not found");

            var mapped = new Client()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                UpdatedAt = DateTime.UtcNow
            };

            await this.clientRepository.UpdateAsync(mapped);

            var result = new ClientForResultDto()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
            };
            return result;
        }

        public async Task GenerateId()
        {
            var result = await this.clientRepository.SelectAllAsync();
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

