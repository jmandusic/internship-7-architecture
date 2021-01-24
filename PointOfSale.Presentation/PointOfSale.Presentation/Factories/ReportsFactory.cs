using PointOfSale.Domain.Factories;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Actions.Reports;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Factories
{
    public static class ReportsFactory
    {
        public static ReportParentAction GetReportParentAction()
        {
            var reports = new List<IAction>
            {
                new AllBillsInCertainTimeSpan
                (
                    RepositoryFactory.GetRepository<BillRepository>(),
                    RepositoryFactory.GetRepository<CategoryRepository>(),
                    RepositoryFactory.GetRepository<ItemRepository>(),
                    RepositoryFactory.GetRepository<ServiceRepository>(),
                    RepositoryFactory.GetRepository<RentRepository>()
                ),
                new SoldItemsPerCategory(RepositoryFactory.GetRepository<CategoryRepository>()),
                new ActiveRents
                (
                    RepositoryFactory.GetRepository<SubscriptionBillRepository>(),
                    RepositoryFactory.GetRepository<RentRepository>()
                ),
                new Top10MostSoldOffers
                (
                    RepositoryFactory.GetRepository<OfferRepository>(),
                    RepositoryFactory.GetRepository<ItemRepository>(),
                    RepositoryFactory.GetRepository<ServiceRepository>(),
                    RepositoryFactory.GetRepository<RentRepository>()
                ),
                new InventoryInteractionReview(RepositoryFactory.GetRepository<ItemRepository>()),
                new ProfitByYear(RepositoryFactory.GetRepository<BillRepository>()),
                new ExitMenuAction()
            };

            var reportParentAction = new ReportParentAction(reports);
            return reportParentAction;
        }
    }
}
