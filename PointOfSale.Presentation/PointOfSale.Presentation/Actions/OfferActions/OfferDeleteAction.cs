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
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete offer";

        public OfferDeleteAction(OfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
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
            PrintHelper.ItemsPrint(_offerRepository.AllItems());
            Console.WriteLine("Enter item Id you want to delete:");
            Console.WriteLine(_offerRepository.ItemDelete(ReadHelper.InputNumberCheck()));

            return;
        }

        public void DeleteService()
        {
            PrintHelper.ServicesPrint(_offerRepository.AllServices());
            Console.WriteLine("Enter service Id you want to delete:");
            Console.WriteLine(_offerRepository.ServiceDelete(ReadHelper.InputNumberCheck()));

            return;
        }

        public void DeleteRent()
        {
            PrintHelper.RentsPrint(_offerRepository.AllRents());
            Console.WriteLine("Enter item Id you want to delete:");
            Console.WriteLine(_offerRepository.RentDelete(ReadHelper.InputNumberCheck()));

            return;
        }
    }
}
