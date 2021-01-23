using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.BillActions
{
    public class SubscriptionBillAction : IAction
    {
        private readonly SubscriptionBillRepository _subscriptionBillRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly CustomerRepository _customerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add subscription bill";

        public SubscriptionBillAction(SubscriptionBillRepository subscriptionBillRepository, InventoryRepository inventoryRepository,
             CustomerRepository customerRepository)
        {
            _subscriptionBillRepository = subscriptionBillRepository;
            _inventoryRepository = inventoryRepository;
            _customerRepository = customerRepository;
        }

        public void Call()
        {
            var rent = new Rent();
            var rents = _inventoryRepository.AvailableRents();
            PrintHelper.RentsPrint(rents);

            Console.WriteLine("Enter rent Id you want to add to bill");
            var index = ReadHelper.InputNumberCheck();

            try
            {
                rent = rents.First(r => r.Id == index);
            }
            catch
            {
                Console.WriteLine("Rent not found, try again");
                Thread.Sleep(1000);
                Console.Clear();
                Call();
                return;
            }

            Console.Clear();

            var customer = new Customer();
            var customers = _customerRepository.AvailableCustomers();

            Console.WriteLine("Enter customer data:");
            Console.WriteLine("Customer personal identification number:");
            var customerID = Console.ReadLine();

            Console.WriteLine("Looking for customer...");
            Thread.Sleep(2000);
            try
            {
                customer = customers.First(c => c.CustomerID == customerID);
                Console.WriteLine("Customer found");

                PrintHelper.CustomerPrint(customer);
                Thread.Sleep(1000);
                Console.Clear();

            }
            catch
            {
                Console.WriteLine("Customer not found");

                Console.WriteLine($"1) Add new customer \n" + 
                                  $" Any key to exit");
                if (Console.ReadLine() !=  "1")
                {
                    return;
                }

                AddCustomer(customer);
            }

            var start = new DateTime();
            var end = new DateTime();

            while (true)
            {
                start = HelpFunctions.CheckDate("Start time");
                end = HelpFunctions.CheckDate("End time");
                if (start < end)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("End time can't be before start time");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            var subscriptionBill = new SubscriptionBill
            {
                StartOfRent = start,
                EndOfRent = end,
                OfferId = rent.OfferId,
                CustomerId = customer.Id
            };

            Console.WriteLine(_subscriptionBillRepository.SubscriptionalBillAdd(subscriptionBill));
            Thread.Sleep(1000);
            Console.Clear();

            PrintHelper.PrintSubscriptionBill(subscriptionBill, rent , customer);

            Console.WriteLine("Press any key and enter to exit");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();

        }



        public void AddCustomer(Customer customer)
        {
            Console.WriteLine("Customer first name:");
            customer.FirstName = ReadHelper.LineInputCheck();

            Console.WriteLine("Customer last name:");
            customer.LastName = ReadHelper.LineInputCheck();

            Console.WriteLine("Customer personal identification number:");
            customer.CustomerID = ReadHelper.LineInputCheck();

            _customerRepository.AddCustomer(customer);

            Console.WriteLine("Customer added");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
