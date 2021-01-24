using Microsoft.EntityFrameworkCore;
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

        public decimal ProfitByYear(int year)
        {
            return DbContext.Bills
                .Where(b => b.isCancelled == false)
                .Where(b => b.PurchasedOn.Year == year)
                .Sum(b => b.TotalPrice);  
        }

        public ICollection<Bill> InCertainTimeSpanWithOfferType(DateTime start, DateTime end,
            string categoryName, int offerType)
        {
            if (categoryName is null)
            {
                return DbContext.Bills
                    .Include(b => b.SubscriptionBills)
                    .ThenInclude(o => o.Offer)
                    .ThenInclude(oc => oc.OfferCategories.Where(oc => (int)oc.Offer.OfferType == offerType))
                    .Where(b => b.PurchasedOn > start && b.PurchasedOn < end && !b.isCancelled)
                    .ToList();
            }
            return DbContext.Bills
                    .Include(b => b.SubscriptionBills)
                    .ThenInclude(o => o.Offer)
                    .ThenInclude(oc => oc.OfferCategories.Where(oc => (int)oc.Offer.OfferType == offerType && oc.Category.NameOfCategory == categoryName))
                    .Where(b => b.PurchasedOn > start && b.PurchasedOn < end && !b.isCancelled)
                    .ToList();
        }

        public ICollection<Bill> InCertainTimeSpanWithoutOfferType(DateTime start, DateTime end,
            string categoryName)
        {
            if (categoryName is null)
            {
                return DbContext.Bills
                    .Where(b => b.PurchasedOn > start && b.PurchasedOn < end && !b.isCancelled)
                    .ToList();
            }
            return DbContext.Bills
                    .Include(b => b.SubscriptionBills)
                    .ThenInclude(o => o.Offer)
                    .ThenInclude(oc => oc.OfferCategories.Where(oc => oc.Category.NameOfCategory == categoryName))
                    .Where(b => b.PurchasedOn > start && b.PurchasedOn < end && !b.isCancelled)
                    .ToList();
        }
    }
}
