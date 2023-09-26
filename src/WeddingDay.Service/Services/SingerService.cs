using System.Security.Cryptography.X509Certificates;
using WeddingDay.Domain.Entities;
using WeddingDay.Data.Repositories;
using WeddingDay.Service.Exceptions;
using WeddingDay.Service.Interfaces;
using WeddingDay.Service.DTOs.SingerDtos;

namespace WeddingDay.Service.Services
{
    public class SingerService : ISingerService
    {
        private long _id;

        Repository<Singer> singerRepository = new Repository<Singer>();
        public async Task<SingerForResultDto> CreateAsync(SingerForResultDto dto)
        {
            var singer = (await this.singerRepository.SelectAllAsync()).FirstOrDefault(s => s.Name.ToLower() == dto.Name.ToLower());
            if (singer == null)
                throw new CustomException(400, "Singer is already exist");
            var mapped = new Singer()
            {
                Id = _id,
                Name = dto.Name,
                Charge = dto.Charge,
                CreatedAt = DateTime.Now,
            };

            await this.singerRepository.InsertAsync(mapped);

            var result = new SingerForResultDto()
            {
                Id = _id,
                Name = dto.Name,
                Charge = dto.Charge
            };
            return result;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var result = await this.singerRepository.SelectByIdAsync(id);
            if (result == null)
                throw new CustomException(404, "Singer is not found");
            throw new NotImplementedException();
        }

        public async Task<List<SingerForResultDto>> GetAllAsync()
        {
            var singers = await this.singerRepository.SelectAllAsync();
            var result = new List<SingerForResultDto>();
            
            foreach ( var singer in singers)
            {
                var mapped = new SingerForResultDto()
                {
                    Id = singer.Id,
                    Name = singer.Name,
                    Charge = singer.Charge,
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
                Id = singer.Id,
                Name = singer.Name,
                Charge = singer.Charge,
            };
            return mapped;
        }

        public async Task<SingerForResultDto> UpdateAsync(SingerForResultDto dto)
        {
            var singer = await this.singerRepository.SelectByIdAsync(dto.Id);
            if (singer == null)
                throw new CustomException(404, "Singer is not found");
            var mapped = new Singer()
            {
                Id = dto.Id,
                Name = dto.Name,
                Charge = dto.Charge,
                UpdatedAt = DateTime.UtcNow
            };

            await this.singerRepository.InsertAsync(mapped);

            var result = new SingerForResultDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Charge = dto.Charge,
            };
            return result;
        }

        public async Task GenerateId()
        {
            var result = await this.singerRepository.SelectAllAsync();

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
