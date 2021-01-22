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

namespace PointOfSale.Presentation.Actions.InventoryActions
{
    public class InventoryEditAction : IAction
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly OfferRepository _offerRepository;
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Inventory offer edit";

        public InventoryEditAction(InventoryRepository inventoryRepository, OfferRepository offerRepository, ItemRepository itemRepository
            , ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _inventoryRepository = inventoryRepository;
            _offerRepository = offerRepository;
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var offer = new Offer();
            var offers = _offerRepository.AllOffers();

            PrintHelper.OffersPrint(_itemRepository.AllItems(),
                _serviceRepository.AllServices(), _rentRepository.AllRents());

            Console.WriteLine("Enter Id of offer which inventory you want to edit");
            var index = ReadHelper.InputNumberCheck();
            try
            {
                offer = offers.First(o => o.Id == index);
            }
            catch
            {
                Console.WriteLine(ResponseResultType.NotFound);
            }

            switch (offer.OfferType)
            {
                case OfferType.Item:
                    EditItem(offer);
                    break;
                case OfferType.Service:
                    EditService(offer);
                    break;
                case OfferType.Rent:
                    EditRent(offer);
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void EditItem(Offer offer)
        {
            var item = _itemRepository.FindItem(offer);

            PrintHelper.ItemPrint(item);
            Console.WriteLine("Quantity: " + item.Quantity);

            while (true)
            {
                Console.WriteLine("1) Add quantity");
                Console.WriteLine("2) Reduce quantity");
                switch (ReadHelper.InputNumberCheck())
                {
                    case 1:
                        Console.WriteLine("How much " + item.Name + " you want to add to inventory");
                        Console.WriteLine(_inventoryRepository.AddQuantity(item, ReadHelper.InputNumberCheck()));
                        return;
                    case 2:
                        Console.WriteLine("How much " + item.Name + " you want to remove from inventory");
                        Console.WriteLine(_inventoryRepository.ReduceQuantity(item, ReadHelper.InputNumberCheck()));
                        return;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        break; ;
                }
            }
        }

        public void EditService(Offer offer)
        {
            var service = _serviceRepository.FindService(offer);

            PrintHelper.ServicePrint(service);
            Console.WriteLine("Availability status: " + service.AvailabilityStatus);

            while (true)
            {
                Console.WriteLine("1) Change availability status");
                Console.WriteLine("2) No changes");
                switch (ReadHelper.InputNumberCheck())
                {
                    case 1:
                        Console.WriteLine(_inventoryRepository.ChangeServiceStatus(service));
                        return;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        break;
                }
            }
        }

        public void EditRent(Offer offer)
        {
            var rent = _rentRepository.FindRent(offer);

            PrintHelper.RentPrint(rent);
            Console.WriteLine("Availability status: " + rent.AvailabilityStatus);

            while (true)
            {
                Console.WriteLine("1) Change availability status");
                Console.WriteLine("2) No changes");
                switch (ReadHelper.InputNumberCheck())
                {
                    case 1:
                        Console.WriteLine(_inventoryRepository.ChangeRentStatus(rent));
                        return;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        break;
                }
            }
        }
    }
}

