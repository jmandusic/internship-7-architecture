using PointOfSale.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Domain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepository<TRepository>() where TRepository : BaseRepository
        {
            var context = DbContextFactory.GetPointOfSaleDbContext();
            return (TRepository) Activator.CreateInstance(typeof(TRepository), context);
        }
    }
}
