using PointOfSale.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Domain.Models
{
    public class Top10MostSoldOffer
    {
        public Offer Offer { get; set; }
        public int Sales { get; set; }
    }
}
