using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class RentRepository : OfferRepository
    {
        public RentRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public Rent FindRent(Offer offer)
        {
            return DbContext.Rents.Where(r => r.OfferId == offer.Id).FirstOrDefault();
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

        public ResponseResultType RentEdit(Rent rent, int index)
        {
            var editRent = DbContext.Rents.Find(index);
            editRent.Name = rent.Name;
            editRent.PricePerHour = rent.PricePerHour;

            return SaveChanges();
        }

        public ICollection<Rent> AllRents()
        {
            return DbContext.Rents.ToList();
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
    }
}
