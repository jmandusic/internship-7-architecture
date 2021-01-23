using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class TraditionalBillRepository : BillRepository
    {
        public TraditionalBillRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }


        public ICollection<TraditionalBill> GetTradBill()
        {
            return new List<TraditionalBill>();
        }

        public decimal TotalPrice(ICollection<TraditionalBill> traditionalBills)
        {
            var totalPrice = 0m;
            foreach (var tradBill in traditionalBills)
            {
                var item = DbContext.Items.First(i => i.OfferId == tradBill.OfferId);
                totalPrice += item.Price * tradBill.Quantity;
            }

            return totalPrice;
        }

        public Bill TraditionallBillAdd(ICollection<TraditionalBill> traditionalBills)
        {
            var billId = AddBill(TotalPrice(traditionalBills), 0);

            foreach (var traditionalBill in traditionalBills)
            {
                var item = DbContext.Items.First(i => i.OfferId == traditionalBill.OfferId);
                traditionalBill.BillId = billId;
                DbContext.TraditionalBills.Add(traditionalBill);
            }
            SaveChanges();

            return DbContext.Bills.Find(billId);
        }
    }
}
