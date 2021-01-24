using System.Collections.Generic;

namespace PointOfSale.Data.Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerID { get; set; }

        public ICollection<SubscriptionBill> SubscriptionBills { get; set; }
    }
}
