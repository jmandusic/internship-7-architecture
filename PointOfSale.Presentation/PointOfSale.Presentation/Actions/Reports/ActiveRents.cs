using PointOfSale.Data.Entities.Models;
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
    public class ActiveRents : IAction
    {
        private readonly SubscriptionBillRepository _subscriptionBillRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "All active rents";

        public ActiveRents(SubscriptionBillRepository subscriptionBillRepository, RentRepository rentRepository)
        {
            _subscriptionBillRepository = subscriptionBillRepository;
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var bills = _subscriptionBillRepository.ActiveRents();
            var rents = _rentRepository.AllRents();

            Console.WriteLine("\t \t ACTIVE RENTS");
            Console.WriteLine();

            if (bills.Count() == 0)
            {
                Console.WriteLine("No active rents at the moment");
                Console.ReadLine();
                Console.Clear();
            }

            foreach (var bill in bills)
            {
                foreach (var rent in rents)
                {
                    if (rent.OfferId == bill.OfferId)
                    {
                        Console.WriteLine($"Rent: {rent.Name} \n" +
                              $"Start of rent: {bill.StartOfRent:dd.MM.yyyy. HH:mm} \n" +
                              $"End of rent: {bill.EndOfRent:dd.MM.yyyy. HH:mm} \n" +
                              $"Customer: {bill.Customer.FirstName} {bill.Customer.LastName} \n" +
                              $"------------------------------------------------------------ \n" +
                              $"Transaction: {bill.Bill.PurchasedOn:dd.MM.yyyy. HH:mm}   Total price: {bill.Bill.TotalPrice}\n \n");
                    }
                }
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
