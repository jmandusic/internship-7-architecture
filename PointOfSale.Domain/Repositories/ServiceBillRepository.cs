using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class ServiceBillRepository : BillRepository
    {
        public ServiceBillRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType ServiceBillAdd(ServiceBill serviceBill, decimal hours)
        {
            var service = DbContext.Services.First(s => s.OfferId == serviceBill.OfferId);
            var totalPrice = service.PricePerHour * hours;
            var billId = AddBill(totalPrice, 1);

            serviceBill.BillId = billId;
            DbContext.ServiceBills.Add(serviceBill);
     
            return SaveChanges();
        }
    }
}
