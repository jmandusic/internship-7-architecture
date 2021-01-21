using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Data.Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public int DailyWorkingHours { get; set; }
        public string StartOfJob { get; set; }


        public ICollection<ServiceBill> ServiceBills { get; set; }

    }
}
