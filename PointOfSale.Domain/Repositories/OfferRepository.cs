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

        public ICollection<Offer> AllOffers()
        {
            return DbContext.Offers.ToList();
        }

        public ICollection<OfferCategory> AllOfferCategories()
        {
            return DbContext.OfferCategories.ToList();
        }
    }
}
