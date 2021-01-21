using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static IList<IAction> GetMainMenuActions()
        {
            var actions = new List<IAction>
            {
                OfferActionsFactory.GetOfferParentAction(),
                CategoryActionsFactory.GetOfferParentAction(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
