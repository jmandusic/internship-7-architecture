using PointOfSale.Data.Entities.Models;

namespace PointOfSale.Domain.Models
{
    public class Top10MostSoldOffer
    {
        public Offer Offer { get; set; }
        public int Sales { get; set; }
    }
}
