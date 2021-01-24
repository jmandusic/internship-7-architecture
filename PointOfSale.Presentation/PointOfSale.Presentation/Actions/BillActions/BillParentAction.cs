using PointOfSale.Presentation.Abstractions;
using System;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Actions.BillActions
{
    public class BillParentAction : BaseParentAction
    {
        public BillParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage bills";
        }

        public override void Call()
        {
            Console.WriteLine("Bill management");
            base.Call();
        }
    }
}
