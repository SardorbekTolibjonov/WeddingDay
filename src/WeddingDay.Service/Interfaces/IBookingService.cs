using WeddingDay.Service.DTOs.BookingDtos;


namespace WeddingDay.Service.Interfaces
{
    public interface IBookingService
    {
        public Task<BookingForResultDto> CreateAsync(BookingForCreationDto dto);
        public Task<BookingForResultDto> UpdateAsync(BookingForUpdateDto dto);
        public Task<bool> DeleteAsync(long id);
        public Task<BookingForResultDto> GetByIdAsync(long id);
        public Task<List<BookingForResultDto>> GetAllAsync();
    }
}
