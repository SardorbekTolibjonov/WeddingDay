using WeddingDay.Data.Repositories;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.SingerDtos;
using WeddingDay.Service.Exceptions;
using WeddingDay.Service.Interfaces;

namespace WeddingDay.Service.Services
{
    public class SingerService : ISingerService
    {
        Repository<Singer> singerRepository = new Repository<Singer>();
        public async Task<List<SingerForResultDto>> GetAllAsync()
        {
            var singers = await this.singerRepository.SelectAllAsync();
            var result = new List<SingerForResultDto>();

            foreach (var singer in singers)
            {
                var mapped = new SingerForResultDto()
                {
                    Id = singer.Id,
                    Name = singer.Name,
                    Fee = singer.Fee,
                };
                result.Add(mapped);
            }
            return result;
        }

        public async Task<SingerForResultDto> GetByIdAsync(long id)
        {
            var singer = await this.singerRepository.SelectByIdAsync(id);
            if (singer == null)
                throw new CustomException(404, "Singer is not found");
            var mapped = new SingerForResultDto()
            {
                Id= singer.Id,
                Name = singer.Name,
                Fee = singer.Fee,
            };
            return mapped;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var singer = await this.singerRepository.SelectByIdAsync(id);
            if (singer == null)
                throw new CustomException(404, "Singer is not found");

            return await this.singerRepository.DeleteAsync(id);
        }
    }
}
