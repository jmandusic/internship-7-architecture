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
    public class OfferAddAction : IAction
    {
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add offer";

        public OfferAddAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
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

            Console.WriteLine(_offerRepository.ItemAdd(item));

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

            Console.WriteLine(_offerRepository.ServiceAdd(service));

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

            Console.WriteLine(_offerRepository.RentAdd(rent));

            return;
        }
    }
}
