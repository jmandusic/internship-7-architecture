using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Helpers
{
    public static class HelpFunctions
    {
        public static OfferType ChooseOfferType()
        {
            while (true)
            {
                Console.WriteLine("Choose offer type");
                Console.WriteLine("1) Item");
                Console.WriteLine("2) Service");
                Console.WriteLine("3) Rent");
                var option = ReadHelper.InputNumberCheck();
                switch (option)
                {
                    case 1:
                        return OfferType.Item;
                    case 2:
                        return OfferType.Service;
                    case 3:
                        return OfferType.Rent;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        public static AvailabilityStatus ChooseAvailabilityStatus()
        {
            while (true)
            {
                Console.WriteLine("Choose availability status");
                Console.WriteLine("1) Available");
                Console.WriteLine("2) Not available due technical difficulties");
                var option = ReadHelper.InputNumberCheck();
                switch (option)
                {
                    case 1:
                        return AvailabilityStatus.Available;
                    case 2:
                        return AvailabilityStatus.NotAvailableDueTechnicalDifficulties;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        public static int ChooseOptionToEditCategory()
        {
            Console.WriteLine("1) Edit category name");
            Console.WriteLine("2) Add offer to category");
            Console.WriteLine("3) Remove offer from category");
            var option = ReadHelper.InputNumberCheck();
            return option;
        }
    }
}
