using PointOfSale.Data.Enums;

namespace PointOfSale.Data.Entities.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public AvailabilityStatus AvailabilityStatus { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
