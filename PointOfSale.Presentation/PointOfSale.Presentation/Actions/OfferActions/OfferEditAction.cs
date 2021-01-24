using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Linq;
using System.Threading;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferEditAction : IAction
    {
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit offer";

        public OfferEditAction(ItemRepository itemRepository, ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }


        public void Call()
        {
            var chooseOffer = HelpFunctions.ChooseOfferType();
            switch (chooseOffer)
            {
                case OfferType.Item:
                    EditItem();
                    break;
                case OfferType.Service:
                    EditService();
                    break;
                case OfferType.Rent:
                    EditRent();
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
            Console.Clear();
            return;
        }

        public void EditItem()
        {
            var items = _itemRepository.AllItems();
            PrintHelper.ItemsPrint(items);

            Console.WriteLine("Enter item Id you want to edit:");
            var index = ReadHelper.InputNumberCheck();

            var item = new Item();
            try
            {
                item = items.First(i => i.Id == index);
            }
            catch
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            Console.WriteLine("Press enter to skip edit");
            Console.WriteLine($"Name: ({item.Name})");
            item.Name = ReadHelper.TryReadLineIfNotEmpty(out var name)
                ? name
                : item.Name;

            Console.WriteLine($"Price: ({item.Price})");
            item.Price = int.TryParse(Console.ReadLine(), out var price)
                ? price
                : item.Price;

            Console.WriteLine(_itemRepository.ItemEdit(item, index));

            return;
        }

        public void EditService()
        {
            var services = _serviceRepository.AllServices();
            PrintHelper.ServicesPrint(services);

            Console.WriteLine("Enter service Id you want to edit:");
            var index = ReadHelper.InputNumberCheck();

            var service = new Service();
            try
            {
                service = services.First(s => s.Id == index);
            }
            catch
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            Console.WriteLine("Press enter to skip edit");
            Console.WriteLine($"Name: ({service.Name})");
            service.Name = ReadHelper.TryReadLineIfNotEmpty(out var name)
                ? name
                : service.Name;

            Console.WriteLine($"Price per hour: ({service.PricePerHour})");
            service.PricePerHour = int.TryParse(Console.ReadLine(), out var price)
                ? price
                : service.PricePerHour;

            Console.WriteLine(_serviceRepository.ServiceEdit(service, index));

            return;
        }

        public void EditRent()
        {
            var rents = _rentRepository.AllRents();
            PrintHelper.RentsPrint(rents);

            Console.WriteLine("Enter rent Id you want to edit:");
            var index = ReadHelper.InputNumberCheck();

            var rent = new Rent();
            try
            {
                rent = rents.First(r => r.Id == index);
            }
            catch
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            Console.WriteLine("Press enter to skip edit");
            Console.WriteLine($"Name: ({rent.Name})");
            rent.Name = ReadHelper.TryReadLineIfNotEmpty(out var name)
                ? name
                : rent.Name;

            Console.WriteLine($"Price per hour: ({rent.PricePerHour})");
            rent.PricePerHour = int.TryParse(Console.ReadLine(), out var price)
                ? price
                : rent.PricePerHour;

            Console.WriteLine(_rentRepository.RentEdit(rent, index));

            return;
        }
    }
}
