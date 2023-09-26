namespace WeddingDay.Service.DTOs.BookingDtos
{
    public class BookingForCreationDto
    {
        public long ClientId { get; set; }
        public DateTime WeddingDate { get; set; }
        public decimal Cost { get; set; }
        public string Singers { get; set; }
        public string WeddingAddress { get; set; }
    }
}
