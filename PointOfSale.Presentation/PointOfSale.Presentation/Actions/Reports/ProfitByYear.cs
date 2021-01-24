using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.Reports
{
    public class ProfitByYear : IAction
    {
        private readonly BillRepository _billRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "View profit by year";

        public ProfitByYear(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public void Call()
        {
            Console.WriteLine("Enter year to see store profit");
            var year = ReadHelper.InputNumberCheck();

            var profit = _billRepository.ProfitByYear(year);
            Console.WriteLine("Total profit in the year " + year + " " + profit);
            Console.ReadLine();
            Console.Clear();
        }

    }
}
