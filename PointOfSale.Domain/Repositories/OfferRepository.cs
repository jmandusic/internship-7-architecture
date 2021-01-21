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
    public class OfferRepository : BaseRepository
    {
        public OfferRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public int OfferAdd(int type)
        {
            var offer = new Offer();
            switch (type)
            {
                case 0:
                    offer.OfferType = OfferType.Item;
                    break;
                case 1:
                    offer.OfferType = OfferType.Service;
                    break;
                case 2:
                    offer.OfferType = OfferType.Rent;
                    break;
                default:
                    break;
            }

            DbContext.Offers.Add(offer);
            SaveChanges();
            return offer.Id;
        }

        public ResponseResultType ItemAdd(Item item)
        {
            if (DbContext.Items.Any(x => item.Name == x.Name))
            {
                return ResponseResultType.AlreadyExists;
            }

            item.OfferId = OfferAdd(0);

            DbContext.Items.Add(item);
            return SaveChanges();
        }

        public ResponseResultType ServiceAdd(Service service)
        {
            if (DbContext.Services.Any(x => service.Name == x.Name))
            {
                return ResponseResultType.AlreadyExists;
            }

            service.OfferId = OfferAdd(1);

            DbContext.Services.Add(service);
            return SaveChanges();
        }

        public ResponseResultType RentAdd(Rent rent)
        {
            if (DbContext.Rents.Any(x => rent.Name == x.Name))
            {
                return ResponseResultType.AlreadyExists;
            }

            rent.OfferId = OfferAdd(2);

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



        public ICollection<Offer> AllOffers()
        {
            return DbContext.Offers.ToList();
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

        public ICollection<Item> AllItemsWithCategory(Category category)
        {
            var items = new List<Item>();
            var allItems = AllItems();
            var offerCategories = AllOfferCategories();

            foreach (var offerCategory in offerCategories)
            {
                foreach (var item in allItems)
                {
                    if (offerCategory.OfferId == item.OfferId && offerCategory.CategoryId == category.Id)
                    {
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        public ICollection<Service> AllServicesWithCategory(Category category)
        {
            var services = new List<Service>();
            var allServices = AllServices();
            var offerCategories = AllOfferCategories();

            foreach (var offerCategory in offerCategories)
            {
                foreach (var service in allServices)
                {
                    if (offerCategory.OfferId == service.OfferId && offerCategory.CategoryId == category.Id)
                    {
                        services.Add(service);
                    }
                }
            }

            return services;
        }

        public ICollection<Rent> AllRentsWithCategory(Category category)
        {
            var rents = new List<Rent>();
            var allRents = AllRents();
            var offerCategories = AllOfferCategories();

            foreach (var offerCategory in offerCategories)
            {
                foreach (var rent in allRents)
                {
                    if (offerCategory.OfferId == rent.OfferId && offerCategory.CategoryId == category.Id)
                    {
                        rents.Add(rent);
                    }
                }
            }

            return rents;
        }

        public ICollection<Item> ItemsWithoutCategory(ICollection<Item> all, ICollection<Item> withCategory)
        {
            var items = new List<Item>();

            foreach (var item in all)
            {
                if (!withCategory.Contains(item))
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public ICollection<Service> ServicessWithoutCategory(ICollection<Service> all, ICollection<Service> withCategory)
        {
            var services = new List<Service>();

            foreach (var service in all)
            {
                if (!withCategory.Contains(service))
                {
                    services.Add(service);
                }
            }
            return services;
        }

        public ICollection<Rent> RentsWithoutCategory(ICollection<Rent> all, ICollection<Rent> withCategory)
        {
            var rents = new List<Rent>();

            foreach (var rent in all)
            {
                if (!withCategory.Contains(rent))
                {
                    rents.Add(rent);
                }
            }
            return rents;
        }

        public ICollection<OfferCategory> AllOfferCategories()
        {
            return DbContext.OfferCategories.ToList();
        }
    }
}
