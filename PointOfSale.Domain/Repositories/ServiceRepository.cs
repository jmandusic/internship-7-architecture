using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class ServiceRepository : OfferRepository
    {
        public ServiceRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public Service FindService(Offer offer)
        {
            var services = AllServices();
            foreach (var service in services)
            {
                if (service.OfferId == offer.Id)
                {
                    return service;
                }
            }
            return new Service();
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

        public ResponseResultType ServiceEdit(Service service, int index)
        {
            var editService = DbContext.Services.Find(index);
            editService.Name = service.Name;
            editService.PricePerHour = service.PricePerHour;

            return SaveChanges();
        }

        public ICollection<Service> AllServices()
        {
            return DbContext.Services.ToList();
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
    }
}
