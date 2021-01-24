using PointOfSale.Data.Enums;
using System;
using System.Threading;

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

        public static TypeOfBill ChooseBillType()
        {
            while (true)
            {
                Console.WriteLine("Choose type of bill");
                Console.WriteLine("1) Traditional");
                Console.WriteLine("2) Service");
                Console.WriteLine("3) Subscription");
                var option = ReadHelper.InputNumberCheck();
                switch (option)
                {
                    case 1:
                        return TypeOfBill.Traditional;
                    case 2:
                        return TypeOfBill.Service;
                    case 3:
                        return TypeOfBill.Subscription;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        public static DateTime CheckDate(string type)
        {
            var date = new DateTime();
            while (true)
            {
                Console.WriteLine("Enter " + type.ToLower() + " of offer (DD/MM/YYYY HH:mm:ss)");
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    if (date < DateTime.Now)
                    {
                        Console.WriteLine(type + " can't be in the past");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong format");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            return date;
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
