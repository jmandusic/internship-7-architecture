using PointOfSale.Domain.Factories;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Actions.BillActions;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Factories
{
    public static class BillActionsFactory
    {
        public static BillParentAction GetBillParentAction()
        {
            var billActions = new List<IAction>
            {
                new TraditionalBillAction
                (
                    RepositoryFactory.GetRepository<TraditionalBillRepository>(),
                    RepositoryFactory.GetRepository<InventoryRepository>(),
                    RepositoryFactory.GetRepository<BillRepository>()
                ),
                new ServiceBillAction
                (
                    RepositoryFactory.GetRepository<ServiceBillRepository>(),
                    RepositoryFactory.GetRepository<InventoryRepository>(),
                    RepositoryFactory.GetRepository<EmployeeRepository>()
                ),
                new SubscriptionBillAction
                (
                    RepositoryFactory.GetRepository<SubscriptionBillRepository>(),
                    RepositoryFactory.GetRepository<InventoryRepository>(),
                    RepositoryFactory.GetRepository<CustomerRepository>()
                ),
                new ExitMenuAction()
            };

            var billParentAction = new BillParentAction(billActions);
            return billParentAction;
        }
    }
}
