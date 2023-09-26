using System.Security.Cryptography;
using WeddingDay.Domain.Entities;
using WeddingDay.Data.Repositories;
using WeddingDay.Service.Exceptions;
using WeddingDay.Service.Interfaces;
using WeddingDay.Service.DTOs.BookingDtos;

namespace WeddingDay.Service.Services
{
    public class BookingService : IBookingService
    {
        Repository<Booking> Repository = new Repository<Booking>();
        private long _id;

        public async Task<BookingForResultDto> CreateAsync(BookingForCreationDto dto)
        {
            var order = (await this.Repository.SelectAllAsync()).FirstOrDefault(o => o.WeddingAddress.ToLower() == dto.WeddingAddress.ToLower());
            if (order is not null)
                throw new CustomException(400, "The wedding hal is already booked");
            var mapped = new Booking()
            {
                Id = _id,
                ClientId = dto.ClientId,
                Cost = dto.Cost,
                Singers = dto.Singers,
                WeddingAddress = dto.WeddingAddress,
                WeddingDate = dto.WeddingDate,
            };
            await Repository.InsertAsync(mapped);
            BookingForResultDto bookingForResultDto = new BookingForResultDto()
            {
                Id= _id,
                ClientId = dto.ClientId,
                Cost = dto.Cost,
                Singers = dto.Singers,
                WeddingAddress = dto.WeddingAddress,
                WeddingDate = dto.WeddingDate
                
            };
            return bookingForResultDto;

        }

        public async Task<bool> RemoveAsync(long id)
        {
            var result = await this.Repository.SelectByIdAsync(id);
            if (result is null)
                throw new CustomException(404, "Order is not found");
            return await Repository.DeleteAsync(id);
        }

        public async Task<List<BookingForResultDto>> GetAllAsync()
        {
            var orders = await this.Repository.SelectAllAsync();
            var res = new List<BookingForResultDto>();

            foreach (var order in orders)
            {
                var mapped = new BookingForResultDto()
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    Cost = order.Cost,
                    Singers = order.Singers,
                    WeddingAddress= order.WeddingAddress,
                    WeddingDate= order.WeddingDate
                };
                res.Add(mapped);
            }
            return res;
        }

        public async Task<BookingForResultDto> GetByIdAsync(long id)
        {
            var result = await this.Repository.SelectByIdAsync(id);
            if (result is null)
                throw new CustomException(404, "Order is not found");

            var mapped = new BookingForResultDto()
            {
                Id = id,
                ClientId = result.ClientId,
                Cost = result.Cost,
                Singers = result.Singers,
                WeddingAddress= result.WeddingAddress,
                WeddingDate= result.WeddingDate

            };
            return mapped;
        }

        public async Task<BookingForResultDto> UpdateAsync(BookingForUpdateDto dto)
        {
            var order = await this.Repository.SelectByIdAsync(dto.Id);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            var mapped = new Booking()
            {
                Id=dto.Id,
                ClientId=dto.ClientId,
                Cost=dto.Cost,
                Singers = dto.Singers,
                WeddingAddress = dto.WeddingAddress,
                WeddingDate = dto.WeddingDate,
                UpdatedAt  = DateTime.UtcNow
            };

            await this.Repository.UpdateAsync(mapped);

            var result = new BookingForResultDto()
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                Cost = dto.Cost,
                Singers = dto.Singers,
                WeddingDate = dto.WeddingDate,
                WeddingAddress = dto.WeddingAddress
            };

            return result;
        }
        public async Task GenerateIdAsync()
        {
            var result = await Repository.SelectAllAsync();
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
