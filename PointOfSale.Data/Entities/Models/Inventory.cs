using PointOfSale.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Data.Entities.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public OfferType OfferType { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
