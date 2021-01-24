using Microsoft.EntityFrameworkCore;
using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
using PointOfSale.Domain.Models;
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

        public ICollection<Offer> AllOffers()
        {
            return DbContext.Offers.ToList();
        }

        public ICollection<OfferCategory> AllOfferCategories()
        {
            return DbContext.OfferCategories.ToList();
        }

        public ICollection<Top10MostSoldOffer> Top10Offers()
        {
            var soldOffers = new List<Top10MostSoldOffer>();

            var items = DbContext.Items
                    .Include(o => o.Offer)
                    .ThenInclude(t => t.TraditionalBills.Where(b => !b.Bill.isCancelled))
                    .ToList()
                    .GroupBy(o => o.Offer)
                    .Select(g => new Top10MostSoldOffer
                    {
                        Offer = g.Key,
                        Sales = g.Sum(o => o.Offer.TraditionalBills.Sum(t => t.Quantity))
                    })
                    .ToList();

            soldOffers.AddRange(items);

            var services = DbContext.Services
                    .Include(o => o.Offer)
                    .ThenInclude(s => s.ServiceBills.Where(b => !b.Bill.isCancelled))
                    .ToList()
                    .GroupBy(o => o.Offer)
                    .Select(g => new Top10MostSoldOffer
                    {
                        Offer = g.Key,
                        Sales = g.Count()
                    })
                    .ToList();

            soldOffers.AddRange(services);

            var rents = DbContext.Rents
                    .Include(o => o.Offer)
                    .ThenInclude(r => r.SubscriptionBills.Where(b => !b.Bill.isCancelled))
                    .ToList()
                    .GroupBy(o => o.Offer)
                    .Select(g => new Top10MostSoldOffer
                    {
                        Offer = g.Key,
                        Sales = g.Count()
                    })
                    .ToList();

            soldOffers.AddRange(rents);

            return soldOffers;
        }
    }
}
