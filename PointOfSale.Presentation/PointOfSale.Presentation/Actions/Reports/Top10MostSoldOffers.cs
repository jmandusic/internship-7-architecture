using PointOfSale.Data.Enums;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.Reports
{
    public class Top10MostSoldOffers : IAction
    {
        private readonly OfferRepository _offerRepository;
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Top 10 most selled offers";

        public Top10MostSoldOffers(OfferRepository offerRepository, ItemRepository itemRepository,
            ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _offerRepository = offerRepository;
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var offers = _offerRepository.Top10Offers();

            Console.WriteLine("\t \t TOP 10 MOST SOLD OFFERS");

            var sortedOffers = offers.OrderByDescending(s => s.Sales).Take(10);
            foreach (var offer in sortedOffers)
            {
                Console.WriteLine();
                PrintHelper.PrintOffer(offer.Offer, _itemRepository, _serviceRepository, _rentRepository);
                Console.WriteLine("Number of sales: " + offer.Sales);
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
