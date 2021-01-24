using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.Reports
{
    public class InventoryInteractionReview : IAction
    {
        private readonly ItemRepository _itemRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Inventory review";

        public InventoryInteractionReview(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Call()
        {
            var type = "";

            var run = true;
            while (run)
            {
                Console.WriteLine("Unesi < ili >");
                type = Console.ReadLine();
                switch (type)
                {
                    case "<":
                        run = false;
                        break;
                    case ">":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }

            Console.WriteLine("Enter quantity you want to check");
            var quantity = ReadHelper.InputNumberCheck();

            if (type == "<")
            {
                Console.WriteLine("\t  ALL ITEMS WITH QUANTITY LESS THAN " + quantity);
                PrintHelper.ItemsLongPrint(_itemRepository.InventoryReport("<", quantity));
            }
            else
            {
                Console.WriteLine("\t  ALL ITEMS WITH QUANTITY MORE THAN " + quantity);
                PrintHelper.ItemsLongPrint(_itemRepository.InventoryReport(">", quantity));
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
