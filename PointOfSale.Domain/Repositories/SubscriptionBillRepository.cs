using Microsoft.EntityFrameworkCore;
using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Domain.Repositories
{
    public class SubscriptionBillRepository : BillRepository
    {
        public SubscriptionBillRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType SubscriptionalBillAdd(SubscriptionBill subscriptionBill)
        {
            var hours = (subscriptionBill.EndOfRent - subscriptionBill.StartOfRent).Hours;
            var rent = DbContext.Rents.First(r => r.OfferId == subscriptionBill.OfferId);
            var totalPrice = rent.PricePerHour * hours;
            var billId = AddBill(totalPrice, 2);

            subscriptionBill.BillId = billId;
            DbContext.SubscriptionBills.Add(subscriptionBill);

            return SaveChanges();
        }

        public ICollection<SubscriptionBill> ActiveRents()
        {
            return DbContext.SubscriptionBills
                 .Include(b => b.Bill)
                 .Include(c => c.Customer)
                 .Include(o => o.Offer)
                 .ThenInclude(r => r.Rents)
                 .Where(sb => sb.StartOfRent < DateTime.Now && sb.EndOfRent > DateTime.Now && !sb.Bill.isCancelled)
                 .ToList();
        }
    }
}
