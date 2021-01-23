using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class BillRepository : BaseRepository
    {
        public BillRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public int AddBill(decimal totalPrice, int type)
        {
            var bill = new Bill
            {
                PurchasedOn = DateTime.Now,
                isCancelled = false,
                TotalPrice = totalPrice
            };
            switch (type)
            {
                case 0:
                    bill.BillType = TypeOfBill.Traditional;
                    break;
                case 1:
                    bill.BillType = TypeOfBill.Service;
                    break;
                case 2:
                    bill.BillType = TypeOfBill.Subscription;
                    break;
                default:
                    break;
            }
            DbContext.Bills.Add(bill);
            SaveChanges();
            return bill.Id;
        }

        public ResponseResultType CancelBill(Bill bill)
        {
            bill.isCancelled = true;
            return SaveChanges();
        }

        public ICollection<Bill> AllBills()
        {
            return DbContext.Bills.ToList();
        }

        public ICollection<TraditionalBill> AllTraditionalBills()
        {
            return DbContext.TraditionalBills.ToList();
        }

        public ICollection<ServiceBill> AllServiceBills()
        {
            return DbContext.ServiceBills.ToList();
        }

        public ICollection<SubscriptionBill> AllSubscriptionBills()
        {
            return DbContext.SubscriptionBills.ToList();
        }
    }
}
