using Models.Identity;

namespace Models
{
    public class DeliveryPerson: User
    {
        public required int DeliveryCompanyId { get; set; }
        public required DeliveryCompany DeliveryCompany { get; set; }
    }
}
