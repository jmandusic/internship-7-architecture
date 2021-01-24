using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PointOfSale.Presentation.Actions.BillActions
{
    public class TraditionalBillAction : IAction
    {
        private readonly TraditionalBillRepository _traditionalBillRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly BillRepository _billRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add traditional bill";

        public TraditionalBillAction(TraditionalBillRepository traditionalBillRepository, InventoryRepository inventoryRepository, 
            BillRepository billRepository)
        {
            _traditionalBillRepository = traditionalBillRepository;
            _inventoryRepository = inventoryRepository;
            _billRepository = billRepository;

        }

        public void Call()
        {
            var itemsOnBill = _traditionalBillRepository.GetTradBill();

            while (true)
            {
                var traditionalBill = new TraditionalBill();

                if (itemsOnBill.Count == _inventoryRepository.AvailableItems().Count)
                {
                    Console.WriteLine("There is no more items left to add");
                    break;
                }
                var result = AddItem(itemsOnBill);
   
                traditionalBill.OfferId = result.item.OfferId;
                traditionalBill.Quantity = result.quantity;

                itemsOnBill.Add(traditionalBill);

                Console.WriteLine("To finish bill enter 1 or any key to continue");
                if (ReadHelper.TryReadLineIfNotEmpty(out var option) && option == "1")
                {
                    break;
                }
            }

            var bill = _traditionalBillRepository.TraditionallBillAdd(itemsOnBill);
            Thread.Sleep(2000);
            Console.Clear();

            PrintHelper.PrintTradBills(itemsOnBill, _inventoryRepository.AvailableItems(), bill);

            Console.WriteLine("Press any key and enter to exit");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
        }

        public (Item item, int quantity) AddItem(ICollection<TraditionalBill> traditionalBills)
        {
            var item = new Item();
            var items = _inventoryRepository.AvailableItems();

            while (true)
            {
                Console.Clear();
                PrintHelper.ItemsPrint(items);

                Console.WriteLine("Choose Id of item you want to add on traditional bill");
                var index = ReadHelper.InputNumberCheck();
                try
                {
                    item = items.First(i => i.Id == index);
                    if (traditionalBills.All(t => t.OfferId != item.OfferId))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't add item which is already on the bill");
                        Thread.Sleep(2500);
                        Console.Clear();
                    }
                }
                catch
                {
                    Console.WriteLine("Not found, try again");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            Console.WriteLine("Available quantity " + item.Quantity);
            Console.WriteLine("Add quantity for " + item.Name);
            var quantity = ReadHelper.InputNumberCheck();
            _inventoryRepository.ReduceQuantity(item, quantity);

            return (item, quantity);
        }
    }
}
