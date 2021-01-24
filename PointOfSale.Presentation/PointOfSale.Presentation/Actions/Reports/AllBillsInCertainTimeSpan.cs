using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Linq;
using System.Threading;

namespace PointOfSale.Presentation.Actions.Reports
{
    public class AllBillsInCertainTimeSpan : IAction
    {
        private readonly BillRepository _billRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "All bills in certain time span";

        public AllBillsInCertainTimeSpan(BillRepository billRepository, CategoryRepository categoryRepository,
            ItemRepository itemRepository, ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _billRepository = billRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var end = new DateTime();

            var start = GetDate("Start");
            while (true)
            {
                end = GetDate("End");
                if (end > start)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("End time can't be before start time");
                }
            }

            var category = new Category();
            var categories = _categoryRepository.AllCategories();

            Console.WriteLine("To view bills in certain category enter 1, press enter to continue");
            if (ReadHelper.TryReadLineIfNotEmpty(out var option) && option == "1")
            {
                while (true)
                {
                    Console.WriteLine("\t \t ALL CATEGORIES");
                    PrintHelper.CategoriesPrint(categories);
                    Console.WriteLine();
                    Console.WriteLine("Enter category Id");
                    var index = ReadHelper.InputNumberCheck();
                    try
                    {
                        category = categories.First(c => c.Id == index);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Category not found, try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            }

            var bills = _billRepository.AllBills();

            Console.WriteLine("To view bills in certain offer type enter 1, press enter to continue");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                bills = _billRepository.InCertainTimeSpanWithOfferType(start, end, 
                    category.NameOfCategory, (int)HelpFunctions.ChooseOfferType());
            }
            else
            {
               bills = _billRepository.InCertainTimeSpanWithoutOfferType(start, end, category.NameOfCategory);
            }

            Console.WriteLine($"All bills from {start:dd.MM.yyyy. HH:mm} to {end:dd.MM.yyyy. HH:mm}");
            if (bills.Count == 0)
            {
                Console.WriteLine("No bills");
            }
            else
            {
                Console.Clear();
                PrintHelper.PrintAllBills(bills);
            }

            Console.ReadLine();
            Console.Clear();
        }

        public DateTime GetDate(string type)
        {
            var date = new DateTime();

            while (true)
            {
                Console.WriteLine("Press enter to set current time or input date");
                Console.WriteLine(type + " time: (dd/MM/yyyy hh:mm:ss)");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    try
                    {
                        date = DateTime.Parse(input);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Wrong format, try again");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else
                {
                    date = DateTime.Now;
                    break;
                }
            }

            return date;
        }
    }
}
