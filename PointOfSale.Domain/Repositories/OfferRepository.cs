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
    public class OfferRepository : BaseRepository
    {
        public OfferRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }


        public ResponseResultType ItemAdd(Item item)
        {
            if (DbContext.Items.Any(x => item.Name == x.Name))
            {
                return ResponseResultType.AlreadyExists;
            }
            DbContext.Items.Add(item);
            return SaveChanges();
        }

        public ResponseResultType ServiceAdd(Service service)
        {
            if (DbContext.Services.Any(x => service.Name == x.Name))
            {
                return ResponseResultType.AlreadyExists;
            }
            DbContext.Services.Add(service);
            return SaveChanges();
        }

        public ResponseResultType RentAdd(Rent rent)
        {
            if (DbContext.Rents.Any(x => rent.Name == x.Name))
            {
                return ResponseResultType.AlreadyExists;
            }
            DbContext.Rents.Add(rent);
            return SaveChanges();
        }



        public ResponseResultType ItemDelete(int index)
        {
            var item = DbContext.Items.Find(index);
            if (item == null)
            {
                return ResponseResultType.NotFound;
            }
            DbContext.Items.Remove(item);
            return SaveChanges();
        }

        public ResponseResultType ServiceDelete(int index)
        {
            var service = DbContext.Services.Find(index);
            if (service == null)
            {
                return ResponseResultType.NotFound;
            }
            DbContext.Services.Remove(service);
            return SaveChanges();
        }

        public ResponseResultType RentDelete(int index)
        {
            var rent = DbContext.Rents.Find(index);
            if (rent == null)
            {
                return ResponseResultType.NotFound;
            }
            DbContext.Rents.Remove(rent);
            return SaveChanges();
        }



        public ResponseResultType ItemEdit(Item item, int index)
        {
            var editItem = DbContext.Items.Find(index);
            editItem.Name = item.Name;
            editItem.Price = item.Price;

            return SaveChanges();
        }

        public ResponseResultType ServiceEdit(Service service, int index)
        {
            var editService = DbContext.Services.Find(index);
            editService.Name = service.Name;
            editService.PricePerHour = service.PricePerHour;

            return SaveChanges();
        }

        public ResponseResultType RentEdit(Rent rent, int index)
        {
            var editRent = DbContext.Rents.Find(index);
            editRent.Name = rent.Name;
            editRent.PricePerHour = rent.PricePerHour;

            return SaveChanges();
        }



        public ICollection<Item> AllItems()
        {
            return DbContext.Items.ToList();
        }

        public ICollection<Service> AllServices()
        {
            return DbContext.Services.ToList();
        }

        public ICollection<Rent> AllRents()
        {
            return DbContext.Rents.ToList();
        }
    }
}
