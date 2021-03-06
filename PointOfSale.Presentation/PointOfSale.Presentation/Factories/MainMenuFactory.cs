﻿using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static IList<IAction> GetMainMenuActions()
        {
            var actions = new List<IAction>
            {
                OfferActionsFactory.GetOfferParentAction(),
                CategoryActionsFactory.GetCategoryParentAction(),
                InventoryActionsFactory.GetInventoryParentAction(),
                BillActionsFactory.GetBillParentAction(),
                ReportsFactory.GetReportParentAction(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
