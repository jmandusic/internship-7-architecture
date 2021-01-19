using PointOfSale.Data.Entities;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.OfferActions
{
    public class OfferEditAction : IAction
    {
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit offer";

        public OfferEditAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
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
            var items = _offerRepository.AllItems();
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

            Console.WriteLine(_offerRepository.ItemEdit(item, index));

            return;
        }

        public void EditService()
        {
            var services = _offerRepository.AllServices();
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

            Console.WriteLine(_offerRepository.ServiceEdit(service, index));

            return;
        }

        public void EditRent()
        {
            var rents = _offerRepository.AllRents();
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

            Console.WriteLine(_offerRepository.RentEdit(rent, index));

            return;
        }
    }
}
