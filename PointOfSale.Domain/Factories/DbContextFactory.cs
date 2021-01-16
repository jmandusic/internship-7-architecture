using Microsoft.EntityFrameworkCore;
using PointOfSale.Data.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PointOfSale.Domain.Factories
{
    public static class DbContextFactory
    {
        public static PointOfSaleDbContext GetPointOfSaleDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["PointOfSale"].ConnectionString).Options;
            return new PointOfSaleDbContext(options);
        }
    }
}
