using WeddingDay.Domain.Commons;

namespace WeddingDay.Domain.Entities
{
    public class Singer : Auditable
    {
        public string Name { get; set; }
        public decimal Charge { get; set; }
    }
}
