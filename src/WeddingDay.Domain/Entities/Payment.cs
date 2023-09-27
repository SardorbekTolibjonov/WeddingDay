using WeddingDay.Domain.Commons;

namespace WeddingDay.Domain.Entities
{
    public class Payment : Auditable
    {
        public decimal Amount { get; set; }
        public string Phone {  get; set; }
    }
}
