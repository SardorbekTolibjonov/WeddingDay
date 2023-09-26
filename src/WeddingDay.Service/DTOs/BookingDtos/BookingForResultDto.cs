namespace WeddingDay.Service.DTOs.BookingDtos
{
    public class BookingForResultDto
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public DateTime WeddingDate { get; set; }
        public decimal Cost { get; set; }
        public string Singers { get; set; }
        public string WeddingAddress { get; set; }
    }
}
