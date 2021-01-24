using PointOfSale.Presentation.Abstractions;
using System;
using System.Collections.Generic;

namespace PointOfSale.Presentation.Actions.Reports
{
    public class ReportParentAction : BaseParentAction
    {
        public ReportParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Reports";
        }

        public override void Call()
        {
            Console.WriteLine("Select report");
            base.Call();
        }
    }
}
