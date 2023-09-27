using WeddingDay.Domain.Commons;

namespace WeddingDay.Domain.Entities
{
    public class Booking : Auditable
    {
        public long ClientId { get; set; }
        public long PaymentId { get; set; }
        public string WeddingDate { get; set; }
        public long SingerId { get; set; }
        public string WeddingAddress { get; set; }
    }
}
