using WeddingDay.Domain.Commons;

namespace WeddingDay.Domain.Entities
{
    public class Booking : Auditable
    {
        public long ClientId { get; set; }
        public DateTime WeddingDate { get; set; }
        public decimal Cost { get; set; }
        public string Singers { get; set; }
        public string WeddingAddress { get; set; }
    }
}
