using PointOfSale.Data.Enums;
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
    public class OfferDeleteAction : IAction
    {
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete offer";

        public OfferDeleteAction(ItemRepository itemRepository, ServiceRepository serviceRepository, RentRepository rentRepository)
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
                    DeleteItem();
                    break;
                case OfferType.Service:
                    DeleteService();
                    break;
                case OfferType.Rent:
                    DeleteRent();
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
            Console.Clear();
            return;
        }

        public void DeleteItem()
        {
            PrintHelper.ItemsPrint(_itemRepository.AllItems());
            Console.WriteLine("Enter item Id you want to delete:");
            Console.WriteLine(_itemRepository.ItemDelete(ReadHelper.InputNumberCheck()));

            return;
        }

        public void DeleteService()
        {
            PrintHelper.ServicesPrint(_serviceRepository.AllServices());
            Console.WriteLine("Enter service Id you want to delete:");
            Console.WriteLine(_serviceRepository.ServiceDelete(ReadHelper.InputNumberCheck()));

            return;
        }

        public void DeleteRent()
        {
            PrintHelper.RentsPrint(_rentRepository.AllRents());
            Console.WriteLine("Enter item Id you want to delete:");
            Console.WriteLine(_rentRepository.RentDelete(ReadHelper.InputNumberCheck()));

            return;
        }
    }
}
