using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
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
    public class BillCancelAction : IAction
    {
        private readonly BillRepository _billRepository;
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Bill cancelation";

        public BillCancelAction(BillRepository billRepository, ItemRepository itemRepository, 
            ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _billRepository = billRepository;
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }

        public void Call()
        {
            var items = _itemRepository.AllItems();
            var services = _serviceRepository.AllServices();
            var rents = _rentRepository.AllRents();

            var tradBills = _billRepository.AllTraditionalBills();
            var serviceBills = _billRepository.AllServiceBills();
            var subscBills = _billRepository.AllSubscriptionBills();
            
            var billType = HelpFunctions.ChooseBillType();
            switch (billType)
            {
                case TypeOfBill.Traditional:
                    //print
                    CancelTradBill(tradBills);
                    break;
                case TypeOfBill.Subscription:
                    PrintHelper.PrintSubscriptionBills(subscBills, rents);
                    CancelSubscBill(subscBills);
                    break;
                case TypeOfBill.Service:
                    PrintHelper.PrintServiceBills(serviceBills, services);
                    CancelServiceBill(serviceBills);
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void CancelTradBill(ICollection<TraditionalBill> traditionalBills)
        {
            var tradBill = new TraditionalBill();

            while (true)
            {
                Console.WriteLine("Choose traditional bill Id you want to cancel");
                var index = ReadHelper.InputNumberCheck();

                try
                {
                    tradBill = traditionalBills.First(t => t.Id == index);
                    break;
                }
                catch
                {
                    Console.WriteLine("Not found, try again");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }

            var bill = _billRepository.AllBills().First(b => b.Id == tradBill.BillId);
            Console.WriteLine(_billRepository.CancelBill(bill));
        }

        public void CancelServiceBill(ICollection<ServiceBill> serviceBills)
        {
            var serviceBill = new ServiceBill();

            while (true)
            {
                Console.WriteLine("Choose service bill Id you want to cancel");
                var index = ReadHelper.InputNumberCheck();

                try
                {
                    serviceBill = serviceBills.First(s => s.Id == index);
                    break;
                }
                catch
                {
                    Console.WriteLine("Not found, try again");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }

            var bill = _billRepository.AllBills().First(b => b.Id == serviceBill.BillId);
            Console.WriteLine(_billRepository.CancelBill(bill));
        }

        public void CancelSubscBill(ICollection<SubscriptionBill> subscriptionBills)
        {
            var subscriptionBill = new SubscriptionBill();

            while (true)
            {
                Console.WriteLine("Choose subscription bill Id you want to cancel");
                var index = ReadHelper.InputNumberCheck();

                try
                {
                    subscriptionBill = subscriptionBills.First(s => s.Id == index);
                    break;
                }
                catch
                {
                    Console.WriteLine("Not found, try again");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }

            var bill = _billRepository.AllBills().First(b => b.Id == subscriptionBill.BillId);
            Console.WriteLine(_billRepository.CancelBill(bill));
        }
    }
}
