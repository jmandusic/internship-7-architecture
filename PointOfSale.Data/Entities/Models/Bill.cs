using PointOfSale.Data.Enums;
using System;
using System.Collections.Generic;

namespace PointOfSale.Data.Entities.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public  TypeOfBill BillType { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchasedOn { get; set; }
        public bool isCancelled { get; set; }


        public ICollection<TraditionalBill> TraditionalBills { get; set; }
        public ICollection<SubscriptionBill> SubscriptionBills { get; set; }
        public ICollection<ServiceBill> ServiceBills { get; set; }

    }
}
