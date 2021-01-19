using PointOfSale.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Helpers
{
    public static class PrintHelper
    {
        public static void ItemPrint(Item item)
        {
            Console.WriteLine($"Id: {item.Id} \n" +
                              $"Item name: {item.Name} \n" +
                              $"Item price: {item.Price}");
        }

        public static void ItemsPrint(ICollection<Item> items)
        {
            foreach (var item in items)
            {
                ItemPrint(item);
                Console.WriteLine();
            }
        }

        public static void ServicePrint(Service service)
        {
            Console.WriteLine($"Id: {service.Id} \n" +
                              $"Service name: {service.Name} \n" +
                              $"Service price per hour: {service.PricePerHour}");
        }

        public static void ServicesPrint(ICollection<Service> services)
        {
            foreach (var service in services)
            {
                ServicePrint(service);
                Console.WriteLine();
            }
        }

        public static void RentPrint(Rent rent)
        {
            Console.WriteLine($"Id: {rent.Id} \n" +
                              $"Rent name: {rent.Name} \n" +
                              $"Rent price per hour: {rent.PricePerHour}");
        }

        public static void RentsPrint(ICollection<Rent> rents)
        {
            foreach (var rent in rents)
            {
                RentPrint(rent);
                Console.WriteLine();
            }
        }
    }
}
