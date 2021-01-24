using PointOfSale.Domain.Factories;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Actions.InventoryActions;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Factories
{
    public static class InventoryActionsFactory
    {
        public static InventoryParentAction GetInventoryParentAction()
        {
            var inventoryActions = new List<IAction>
            {
                new InventoryEditAction
                (
                    RepositoryFactory.GetRepository<InventoryRepository>(),
                    RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<ItemRepository>(),
                    RepositoryFactory.GetRepository<ServiceRepository>(),
                    RepositoryFactory.GetRepository<RentRepository>()
                ),
                new InventoryAllItemsStateAction
                (
                    RepositoryFactory.GetRepository<InventoryRepository>(),
                    RepositoryFactory.GetRepository<ItemRepository>()
                ),
                new InventoryGetAvailableServicesAction(RepositoryFactory.GetRepository<InventoryRepository>()),
                new InventoryGetAvailableRentsAction(RepositoryFactory.GetRepository<InventoryRepository>()),
                new ExitMenuAction()
            };

            var offerParentAction = new InventoryParentAction(inventoryActions);
            return offerParentAction;
        }
    }
}
