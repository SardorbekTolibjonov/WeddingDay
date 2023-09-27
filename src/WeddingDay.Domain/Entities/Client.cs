using WeddingDay.Domain.Commons;

namespace WeddingDay.Domain.Entities
{
    public class Client : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Password { get; set; }
    }
}
