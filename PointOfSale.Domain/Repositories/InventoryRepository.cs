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
    public class InventoryRepository : BaseRepository
    {
        public InventoryRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType AddQuantity(Item item, int quantity)
        {
            item.Quantity += quantity;
            return SaveChanges();
        }

        public ResponseResultType ReduceQuantity(Item item, int quantity)
        {
            item.Quantity -= quantity;
            return SaveChanges();
        }

        public ResponseResultType ChangeServiceStatus(Service service)
        {
            if (service.AvailabilityStatus == AvailabilityStatus.Available)
            {
                service.AvailabilityStatus = AvailabilityStatus.NotAvailableDueTechnicalDifficulties;
            }
            else
            {
                service.AvailabilityStatus = AvailabilityStatus.Available;
            }

            return SaveChanges();
        }

        public ResponseResultType ChangeRentStatus(Rent rent)
        {
            if (rent.AvailabilityStatus == AvailabilityStatus.Available)
            {
                rent.AvailabilityStatus = AvailabilityStatus.NotAvailableDueTechnicalDifficulties;
            }
            else
            {
                rent.AvailabilityStatus = AvailabilityStatus.Available;
            }

            return SaveChanges();
        }

        public ICollection<Service> AvailableServices()
        {
            var services = DbContext.Services
                .Where(s => s.AvailabilityStatus == AvailabilityStatus.Available)
                .ToList();
            return services;
        }

        public ICollection<Rent> AvailableRents()
        {
            var rents = DbContext.Rents
                .Where(r => r.AvailabilityStatus == AvailabilityStatus.Available)
                .ToList();
            return rents;
        }
    }
}
