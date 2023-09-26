using WeddingDay.Data.Repositories;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.BookingDtos;
using WeddingDay.Service.DTOs.WeddingDtos;
using WeddingDay.Service.Interfaces;

namespace WeddingDay.Service.Services
{
    public class WeddingService : IWeddingService 
    {
        private long _id;
        Repository<Wedding> Repository = new Repository<Wedding>();
        public Task<WeddingForResultDto> CreateAsync(WeddingForCreationDto dto)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WeddingForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WeddingForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<WeddingForResultDto> UpdateAsync(WeddingForUpdateDto dto)
        {
            throw new NotImplementedException();
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
