namespace WeddingDay.Service.DTOs.BookingDtos
{
    public class BookingForCreationDto
    {
        public long ClientId { get; set; }
        public long PaymentId { get; set; }
        public string WeddingDate { get; set; }
        public long SingerId { get; set; }
        public string WeddingAddress { get; set; }
    }
}
