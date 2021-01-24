using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Threading;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferAddAction : IAction
    {
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add offer";

        public OfferAddAction(ItemRepository itemRepository, ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }


        public void Call()
        {
            var offerType = HelpFunctions.ChooseOfferType();
            switch (offerType)
            {
                case OfferType.Item:
                    AddItem();
                    break;
                case OfferType.Service:
                    AddService();
                    break;
                case OfferType.Rent:
                    AddRent();
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
            Console.Clear();
            return;
        }

        public void AddItem()
        {
            var item = new Item();

            Console.WriteLine("Item name:");
            item.Name = ReadHelper.LineInputCheck();

            Console.WriteLine("Item price:");
            item.Price = ReadHelper.InputNumberCheck();

            Console.WriteLine("Item quantity:");
            item.Quantity = ReadHelper.InputNumberCheck();

            Console.WriteLine(_itemRepository.ItemAdd(item));

            return;
        }

        public void AddService()
        {
            var service = new Service();

            Console.WriteLine("Service name:");
            service.Name = ReadHelper.LineInputCheck();

            Console.WriteLine("Service price per hour:");
            service.PricePerHour = ReadHelper.InputNumberCheck();

            service.AvailabilityStatus = HelpFunctions.ChooseAvailabilityStatus();

            Console.WriteLine(_serviceRepository.ServiceAdd(service));

            return;
        }
        public void AddRent()
        {
            var rent = new Rent();

            Console.WriteLine("Rent name:");
            rent.Name = ReadHelper.LineInputCheck();

            Console.WriteLine("Rent price per hour:");
            rent.PricePerHour = ReadHelper.InputNumberCheck();

            rent.AvailabilityStatus = HelpFunctions.ChooseAvailabilityStatus();

            Console.WriteLine(_rentRepository.RentAdd(rent));

            return;
        }
    }
}
