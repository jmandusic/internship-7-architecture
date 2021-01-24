using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Domain.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public EmployeeRepository(PointOfSaleDbContext dbContext) : base(dbContext)
        {
        }


        public ICollection<Employee> AvailableEmployees()
        {
            var employees = DbContext.Employees
                .ToList();
            return employees;
        }
    }
}
