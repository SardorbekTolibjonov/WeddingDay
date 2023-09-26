using WeddingDay.Data.Repositories;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.BookingDtos;
using WeddingDay.Service.DTOs.WeddingDtos;
using WeddingDay.Service.Exceptions;
using WeddingDay.Service.Interfaces;

namespace WeddingDay.Service.Services
{
    public class WeddingService : IWeddingService 
    {
        private long _id;
        Repository<Wedding> Repository = new Repository<Wedding>();
        public async Task<WeddingForResultDto> CreateAsync(WeddingForCreationDto dto)
        {
            var wedding  = (await this.Repository.SelectAllAsync()).FirstOrDefault(w => w.Address.ToLower() == dto.Address.ToLower());
            if (wedding == null)
                throw new CustomException(400, "Wedding is already exsist");

            var mapped = new Wedding()
            {
                Id = _id,
                Address = dto.Address,
                Cost = dto.Cost,
                CreatedAt = DateTime.UtcNow
            };

            await this.Repository.InsertAsync(mapped);

            var result = new WeddingForResultDto()
            {
                Id = _id,
                Address = dto.Address,
                Cost = dto.Cost,
            };

            return result;
        }
        public async Task<bool> RemoveAsync(long id)
        {
            var wedding = await this.Repository.SelectByIdAsync(id);
            if (wedding == null)
                throw new CustomException(404, "Wedding is not found");

            return await this.Repository.DeleteAsync(id);
        }

        public async Task<List<WeddingForResultDto>> GetAllAsync()
        {
            var weddings = await this.Repository.SelectAllAsync();
            var result = new List<WeddingForResultDto>();

            foreach(var wedding in weddings )
            {
                var mapped = new WeddingForResultDto()
                {
                    Id = wedding.Id,
                    Address = wedding.Address,
                    Cost = wedding.Cost,
                };
                result.Add(mapped);
            }

            return result;
        }

        public async Task<WeddingForResultDto> GetByIdAsync(long id)
        {
            var wedding = await this.Repository.SelectByIdAsync(id);
            if (wedding == null)
                throw new CustomException(404, "Wedding is not found");
            var mapped = new WeddingForResultDto()
            {
                Id = wedding.Id,
                Address = wedding.Address,
                Cost = wedding.Cost,
            };
            return mapped;
        }

        public async Task<WeddingForResultDto> UpdateAsync(WeddingForUpdateDto dto)
        {
            var wedding = await this.Repository.SelectByIdAsync(dto.Id);
            if (wedding == null)
                throw new CustomException(404, "Wedding is not found");

            var mapped = new Wedding()
            {
                Id = dto.Id,
                Address = dto.Address,
                Cost = dto.Cost,
                UpdatedAt = DateTime.UtcNow
            };

            await this.Repository.UpdateAsync(mapped);

            var result = new WeddingForResultDto()
            {
                Id = dto.Id,
                Address = dto.Address,
                Cost = dto.Cost,
            };
            return result;
        }

        public async Task GenerateIdAsync()
        {
            var result = await Repository.SelectAllAsync();
            if (result.Count == 0)
            {
                _id = 1;
            }
            else
            {
                var res = result[result.Count - 1];
                _id = ++res.Id;
            }
        }

        
    }
}
