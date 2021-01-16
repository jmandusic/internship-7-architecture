using PointOfSale.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Data.Entities.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public OfferType OfferType { get; set; }
   

        public ICollection<OfferCategory> OfferCategories { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Rent> Rents { get; set; }

        public ICollection<TraditionalBill> TraditionalBills { get; set; }
        public ICollection<ServiceBill> ServiceBills { get; set; }
        public ICollection<SubscriptionBill> SubscriptionBills { get; set; }
    }
}
