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
    }
}
