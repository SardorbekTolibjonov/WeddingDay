using WeddingDay.Domain.Commons;

namespace WeddingDay.Domain.Entities
{
    public class Wedding : Auditable
    {
        public string Address { get; set; }
        public decimal Cost { get; set; }
    }
}
