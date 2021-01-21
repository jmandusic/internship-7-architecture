using Microsoft.EntityFrameworkCore;
using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType CategoryAdd(Category category)
        {
            if (DbContext.Categories.Any(c => category.NameOfCategory == c.NameOfCategory))
            {
                return ResponseResultType.AlreadyExists;
            }

            DbContext.Categories.Add(category);
            return SaveChanges();
        }

        public ResponseResultType CategoryDelete(int index)
        {
            var category = DbContext.Categories.Find(index);
            if (category == null)
            {
                return ResponseResultType.NotFound;
            }
            DbContext.Categories.Remove(category);
            return SaveChanges();
        }

        public ResponseResultType CategoryEditName(Category category)
        {
            var editCategory = DbContext.Categories.Find(category.Id);
            editCategory.NameOfCategory = category.NameOfCategory;

            return SaveChanges();
        }

        public ResponseResultType AddOfferToCategory(int categoryId, int offerId)
        {
            try
            {
                var offer = DbContext.Offers.Find(offerId);
            }
            catch
            {
                return ResponseResultType.NotFound;
            }

            if (DbContext.OfferCategories.Any(oc => oc.CategoryId == categoryId && oc.OfferId == offerId))
            {
                return ResponseResultType.AlreadyExists;
            }

            var offerCategory = new OfferCategory()
            {
                OfferId = offerId,
                CategoryId = categoryId
            };

            DbContext.OfferCategories.Add(offerCategory);
            return SaveChanges();
        }

        public ResponseResultType DeleteOfferFromCategory(int categoryId, int offerId)
        {
            var offerCategories = DbContext.OfferCategories
                .Where(oc => oc.OfferId == offerId && oc.CategoryId == categoryId)
                .ToList();

            if (offerCategories == null)
            {
                return ResponseResultType.NotFound;
            }

            foreach (var offerCategory in offerCategories)
            {
                DbContext.OfferCategories.Remove(offerCategory);
            }

            return SaveChanges();
        }


        public ICollection<OfferCategory> GetOffersFromCategory(Category category)
        {
            return DbContext.OfferCategories
                .Include(c => c.Category)
                .Where(c => c.CategoryId == category.Id)
                .ToList();
        }

        public ICollection<Category> AllCategories()
        {
            return DbContext.Categories.ToList();
        }
    }
}
