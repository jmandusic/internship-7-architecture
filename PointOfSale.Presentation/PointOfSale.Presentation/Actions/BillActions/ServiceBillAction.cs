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
    public class ServiceBillAction : IAction
    {
        private readonly ServiceBillRepository _serviceBillRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly EmployeeRepository _employeeRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add service bill";

        public ServiceBillAction(ServiceBillRepository serviceBillRepository, InventoryRepository inventoryRepository,
             EmployeeRepository employeeRepository)
        {
            _serviceBillRepository = serviceBillRepository;
            _inventoryRepository = inventoryRepository;
            _employeeRepository = employeeRepository;
        }

        public void Call()
        {
            var service = new Service();
            var services = _inventoryRepository.AvailableServices();
            PrintHelper.ServicesPrint(services);

            Console.WriteLine("Enter service Id you want to add to bill");
            var index = ReadHelper.InputNumberCheck();

            try
            {
                service = services.First(s => s.Id == index);
            }
            catch
            {
                Console.WriteLine("Service not found, try again");
                Thread.Sleep(1000);
                Console.Clear();
                Call();
                return;
            }

            Console.Clear();

            var employee = new Employee();
            var employees = _employeeRepository.AvailableEmployees();

            while (true)
            {
                PrintHelper.EmployeesPrint(employees);

                Console.WriteLine("Enter employee Id you want to work on " + service.Name);
                var employeeId = ReadHelper.InputNumberCheck();

                try
                {
                    employee = employees.First(e => e.Id == employeeId);
                    break;
                }
                catch
                {
                    Console.WriteLine("Employee not found, try again");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Call();
                    return;
                }
            }

            Console.Clear();

            Console.WriteLine("Enter hours of service");
            Console.WriteLine("For example: 2,5 for 2 and a half hours");
            var hours = decimal.Parse(Console.ReadLine());

            var scheduledOn = HelpFunctions.CheckDate("Start time");
            
            var serviceBill = new ServiceBill
            {
                EmployeeId = employee.Id,
                OfferId = service.OfferId,
                ScheduledOn = scheduledOn
            };


            Console.WriteLine(_serviceBillRepository.ServiceBillAdd(serviceBill, hours));
            Thread.Sleep(1000);
            Console.Clear();

            PrintHelper.PrintServiceBill(serviceBill, service, employee);

            Console.WriteLine("Press any key and enter to exit");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();

        }
    }
}
