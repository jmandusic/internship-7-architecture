using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
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

        public static void CategoryPrint(Category category)
        {
            Console.WriteLine($"Id: {category.Id} \n" +
                              $"Category name: {category.NameOfCategory}");
        }

        public static void CategoriesPrint(ICollection<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryPrint(category);
                Console.WriteLine();
            }
        }

        public static void OffersPrint(ICollection<Item> items, ICollection<Service> services, ICollection<Rent> rents)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Id: {item.OfferId} \n" +
                          $"Name: {item.Name} \n");
            }

            foreach (var service in services)
            {
                Console.WriteLine($"Id: {service.OfferId} \n" +
                          $"Name: {service.Name} \n");
            }

            foreach (var rent in rents)
            {
                Console.WriteLine($"Id: {rent.OfferId} \n" +
                          $"Name: {rent.Name} \n");
            }

            if (items.Count == 0 && services.Count == 0 && rents.Count == 0)
            {
                Console.WriteLine("No offers at the moment");
            }
        }
    }
}
