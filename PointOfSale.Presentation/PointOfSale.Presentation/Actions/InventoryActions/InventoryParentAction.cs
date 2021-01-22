﻿using PointOfSale.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.InventoryActions
{
    public class InventoryParentAction : BaseParentAction
    {
        public InventoryParentAction(IList<IAction> actions) : base(actions)
        {
            Label = "Manage inventory";
        }

        public override void Call()
        {
            Console.WriteLine("Inventory management");
            base.Call();
        }
    }
}
