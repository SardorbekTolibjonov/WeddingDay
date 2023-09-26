using System.Security.Cryptography;
using WeddingDay.Data.Repositories;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.BookingDtos;
using WeddingDay.Service.Interfaces;

namespace WeddingDay.Service.Services
{
    public class BookingService : IBookingService
    {
        Repository<Booking> Repository = new Repository<Booking>();
        private long _id;
        public async Task<BookingForResultDto> CreateAsync(BookingForCreationDto dto)
        {
            var Booking = new Booking()
            {
                Id = _id,
                ClientId = dto.ClientId,
                Cost = dto.Cost,
                Singers = dto.Singers,
                WeddingAddress = dto.WeddingAddress,
                WeddingDate = dto.WeddingDate,
            };
            await Repository.InsertAsync(Booking);
            BookingForResultDto bookingForResultDto = new BookingForResultDto()
            {
                Id= _id,
                ClientId = dto.ClientId,
                Cost = dto.Cost,
                Singers = dto.Singers,
                WeddingAddress = dto.WeddingAddress,
                WeddingDate = dto.WeddingDate
                
            };

        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookingForResultDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingForResultDto> UpdateAsync(BookingForUpdateDto dto)
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
