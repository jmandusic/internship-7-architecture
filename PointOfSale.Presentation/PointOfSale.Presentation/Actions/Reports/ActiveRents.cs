using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using System;
using System.Linq;

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
                return;
            }

            foreach (var bill in bills)
            {
                var rent = _rentRepository.FindRent(bill.Offer);

                Console.WriteLine($"Rent: {rent.Name} \n" +
                                  $"Customer: {bill.Customer.FirstName} {bill.Customer.LastName}\n" +
                                  $"Transaction: {bill.Bill.PurchasedOn}\n" +
                                  $"Total price: {bill.Bill.TotalPrice}\n");
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
