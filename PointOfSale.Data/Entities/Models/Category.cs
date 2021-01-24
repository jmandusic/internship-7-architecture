using System.Collections.Generic;

namespace PointOfSale.Data.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }

        public ICollection<OfferCategory> OfferCategories { get; set; }
    }
}
