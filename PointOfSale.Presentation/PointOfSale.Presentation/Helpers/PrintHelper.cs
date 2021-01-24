using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Repositories;
using System;
using System.Collections.Generic;

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

        public static void ItemLongPrint(Item item)
        {
            Console.WriteLine($"Id: {item.Id} \n" +
                              $"Item name: {item.Name} \n" +
                              $"Item price: {item.Price} \n" +
                              $"Item quantity: {item.Quantity}");
        }

        public static void ItemsPrint(ICollection<Item> items)
        {
            foreach (var item in items)
            {
                ItemPrint(item);
                Console.WriteLine();
            }
        }

        public static void ItemsLongPrint(ICollection<Item> items)
        {
            foreach (var item in items)
            {
                ItemLongPrint(item);
                Console.WriteLine();
            }
        }

        public static void ServicePrint(Service service)
        {
            Console.WriteLine($"Id: {service.Id} \n" +
                              $"Service name: {service.Name} \n" +
                              $"Service price per hour: {service.PricePerHour}");
        }

        public static void ServiceLongPrint(Service service)
        {
            Console.WriteLine($"Id: {service.Id} \n" +
                              $"Service name: {service.Name} \n" +
                              $"Service price per hour: {service.PricePerHour} \n" +
                              $"Service status: {service.AvailabilityStatus}");
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

        public static void RentLongPrint(Rent rent)
        {
            Console.WriteLine($"Id: {rent.Id} \n" +
                              $"Rent name: {rent.Name} \n" +
                              $"Rent price per hour: {rent.PricePerHour} \n" +
                              $"Rent status: {rent.AvailabilityStatus}");
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

        public static void PrintTradBill(TraditionalBill traditionalBill, Item item)
        {
            Console.WriteLine($"Item: {item.Name} \n" + 
                              $"Quantity: {traditionalBill.Quantity} \n" +
                              $"--------------------------------------- \n");
        }

        public static void PrintTradBills(ICollection<TraditionalBill> traditionalBills, ICollection<Item> items, Bill bill)
        {
            foreach (var traditionalBill in traditionalBills)
            {
                foreach (var item in items)
                {
                    if (traditionalBill.OfferId == item.OfferId)
                    {
                        PrintTradBill(traditionalBill, item);
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("_________________________________________________________ \n");
            Console.WriteLine($"Transaction: {bill.PurchasedOn:dd.MM.yyyy. HH:mm}   Total price: {bill.TotalPrice}");
        }

        public static void PrintServiceBill(ServiceBill serviceBill, Service service, Employee employee)
        {
            Console.WriteLine($"Service: {service.Name} \n" +
                              $"Start of service: {serviceBill.ScheduledOn:dd.MM.yyyy. HH:mm} \n" + 
                              $"Employee: {employee.FirstName} {employee.LastName} \n" +
                              $"------------------------------------------------------------ \n" + 
                              $"Transaction: {serviceBill.Bill.PurchasedOn:dd.MM.yyyy. HH:mm}   Total price: {serviceBill.Bill.TotalPrice}");
        }

        public static void PrintServiceBills(ICollection<ServiceBill> serviceBills, ICollection<Service> services)
        {
            foreach (var serviceBill in serviceBills)
            {
                foreach (var service in services)
                {
                    if (serviceBill.OfferId == service.OfferId)
                    {
                        PrintServiceBill(serviceBill, service, serviceBill.Employee);
                        Console.WriteLine();
                    }
                }
            }
        }


        public static void PrintSubscriptionBill(SubscriptionBill subscriptionBill, Rent rent, Customer customer)
        {
            Console.WriteLine($"Rent: {rent.Name} \n" +
                              $"Start of rent: {subscriptionBill.StartOfRent:dd.MM.yyyy. HH:mm} \n" +
                              $"End of rent: {subscriptionBill.EndOfRent:dd.MM.yyyy. HH:mm} \n" +
                              $"Customer: {customer.FirstName} {customer.LastName} \n" +
                              $"------------------------------------------------------------ \n" +
                              $"Transaction: {subscriptionBill.Bill.PurchasedOn:dd.MM.yyyy. HH:mm}   Total price: {subscriptionBill.Bill.TotalPrice}");
        }

        public static void PrintSubscriptionBills(ICollection<SubscriptionBill> subscriptionBills, ICollection<Rent> rents)
        {
            foreach (var subscriptionBill in subscriptionBills)
            {
                foreach (var rent in rents)
                {
                    if (subscriptionBill.OfferId == rent.OfferId)
                    {
                        PrintSubscriptionBill(subscriptionBill, rent, subscriptionBill.Customer);
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void PrintAllBills(ICollection<Bill> bills)
        {
            foreach (var bill in bills)
            {
                Console.WriteLine($"Bill type: {bill.BillType} \n" + 
                                  $"Transaction: {bill.PurchasedOn} \n" + 
                                  $"Total price: {bill.TotalPrice} \n");
            }
        }
        public static void EmployeePrint(Employee employee)
        {
            Console.WriteLine($"Id: {employee.Id} \n" +
                              $"First name: {employee.FirstName} \n" +
                              $"Last name: {employee.LastName}");
        }

        public static void EmployeesPrint(ICollection<Employee> employees)
        {
            foreach (var employee in employees)
            {
                EmployeePrint(employee);
                Console.WriteLine();
            }
        }

        public static void CustomerPrint(Customer customer)
        {
            Console.WriteLine($"Id: {customer.Id} \n" +
                              $"First name: {customer.FirstName} \n" +
                              $"Last name: {customer.LastName}");
        }

        public static void CustomersPrint(ICollection<Customer> customers)
        {
            foreach (var customer in customers)
            {
                CustomerPrint(customer);
                Console.WriteLine();
            }
        }

        public static void PrintOffer(Offer offer, ItemRepository itemRepository,
            ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            switch (offer.OfferType)
            {
                case OfferType.Item:
                    var item = itemRepository.FindItem(offer);
                    ItemPrint(item);
                    break;
                case OfferType.Service:
                    var service = serviceRepository.FindService(offer);
                    ServicePrint(service);
                    break;
                case OfferType.Rent:
                    var rent = rentRepository.FindRent(offer);
                    RentPrint(rent);
                    break;
                default:
                    break;
            }
        }
    }
}
