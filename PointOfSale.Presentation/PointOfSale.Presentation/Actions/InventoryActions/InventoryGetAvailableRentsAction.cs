using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Threading;

namespace PointOfSale.Presentation.Actions.InventoryActions
{
    public class InventoryGetAvailableRentsAction : IAction
    {
        private readonly InventoryRepository _inventoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "See available rents";

        public InventoryGetAvailableRentsAction(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public void Call()
        {
            Console.WriteLine("\t \t AVAILABLE RENTS");
            PrintHelper.RentsPrint(_inventoryRepository.AvailableRents());

            Console.WriteLine("Press any key and enter to exit");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
