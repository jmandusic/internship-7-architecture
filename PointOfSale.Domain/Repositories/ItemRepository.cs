using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class ItemRepository : OfferRepository
    {
        public ItemRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public Item FindItem(Offer offer)
        {
            return DbContext.Items.First(i => i.OfferId == offer.Id);
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

        public ResponseResultType ItemEdit(Item item, int index)
        {
            var editItem = DbContext.Items.Find(index);
            editItem.Name = item.Name;
            editItem.Price = item.Price;

            return SaveChanges();
        }

        public ICollection<Item> AllItems()
        {
            return DbContext.Items.ToList();
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

        public ICollection<Item> InventoryReport(string type, int quantity)
        {
            if (type == ">")
            {
                return DbContext.Items
                    .Where(i => i.Quantity > quantity)
                    .ToList();
            }
            return DbContext.Items
                    .Where(i => i.Quantity < quantity)
                    .ToList();
        }


    }
}
