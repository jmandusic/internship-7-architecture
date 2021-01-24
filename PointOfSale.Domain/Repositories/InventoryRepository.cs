using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Domain.Repositories
{
    public class InventoryRepository : BaseRepository
    {
        public InventoryRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType AddQuantity(Item item, int quantity)
        {
            var edited = DbContext.Items.Find(item.Id);
            edited.Quantity += quantity;
            return SaveChanges();
        }

        public ResponseResultType ReduceQuantity(Item item, int quantity)
        {
            var edited = DbContext.Items.Find(item.Id);
            edited.Quantity -= quantity;
            if (edited.Quantity < 0)
            {
                edited.Quantity = 0;
            }
            return SaveChanges();
        }

        public ResponseResultType ChangeServiceStatus(Service service)
        {
            var edited = DbContext.Services.Find(service.Id);

            if (edited.AvailabilityStatus == AvailabilityStatus.Available)
            {
                edited.AvailabilityStatus = AvailabilityStatus.NotAvailableDueTechnicalDifficulties;
            }
            else
            {
                edited.AvailabilityStatus = AvailabilityStatus.Available;
            }

            return SaveChanges();
        }

        public ResponseResultType ChangeRentStatus(Rent rent)
        {
            var edited = DbContext.Rents.Find(rent.Id);

            if (edited.AvailabilityStatus == AvailabilityStatus.Available)
            {
                edited.AvailabilityStatus = AvailabilityStatus.NotAvailableDueTechnicalDifficulties;
            }
            else
            {
                edited.AvailabilityStatus = AvailabilityStatus.Available;
            }

            return SaveChanges();
        }


        public ICollection<Item> AvailableItems()
        {
            var items = DbContext.Items
                .Where(i => i.Quantity > 0)
                .ToList();
            return items;
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
