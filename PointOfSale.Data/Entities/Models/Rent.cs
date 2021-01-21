using PointOfSale.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Data.Entities.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public AvailabilityStatus AvailabilityStatus { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
