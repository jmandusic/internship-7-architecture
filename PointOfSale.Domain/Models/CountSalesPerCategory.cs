using PointOfSale.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Domain.Models
{
    public class CountSalesPerCategory
    {
        public string NameOfcategory { get; set; }
        public int Sales { get; set; }
    }
}
