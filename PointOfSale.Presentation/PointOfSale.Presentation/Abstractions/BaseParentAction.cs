using PointOfSale.Presentation.Actions;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Abstractions
{
    public abstract class BaseParentAction : IParentAction
    {
        public int MenuIndex { get; set; }
        public string Label { get; set; }
        public IList<IAction> Actions { get; set; }

        protected BaseParentAction(IList<IAction> actions)
        {
            actions.SetActionIndexes();
            Actions = actions;
        }

        public virtual void Call()
        {
            Actions.PrintActionsAndCall();
        }
    }
}
