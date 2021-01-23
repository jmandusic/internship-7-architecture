using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.Domain.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public CustomerRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }

        public void AddCustomer(Customer customer)
        {
            DbContext.Customers.Add(customer);
            SaveChanges();
        }

        public ICollection<Customer> AvailableCustomers()
        {
            var customers = DbContext.Customers
                .ToList();
            return customers;
        }
    }
}
