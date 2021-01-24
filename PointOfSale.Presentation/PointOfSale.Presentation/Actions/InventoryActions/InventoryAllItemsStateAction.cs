using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Threading;

namespace PointOfSale.Presentation.Actions.InventoryActions
{
    public class InventoryAllItemsStateAction : IAction
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly ItemRepository _itemRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "See state of all items";

        public InventoryAllItemsStateAction(InventoryRepository inventoryRepository, ItemRepository itemRepository)
        {
            _inventoryRepository = inventoryRepository;
            _itemRepository = itemRepository;
        }

        public void Call()
        {
            Console.WriteLine("\t \t ALL ITEMS STATE");
            Console.WriteLine();
            foreach (var item in _itemRepository.AllItems())
            {
                PrintHelper.ItemPrint(item);
                Console.WriteLine("Quantity: " + item.Quantity);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key and enter to exit");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
