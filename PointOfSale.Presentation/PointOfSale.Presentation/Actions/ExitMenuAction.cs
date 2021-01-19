using PointOfSale.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions
{
    public class ExitMenuAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Exit menu";

        public ExitMenuAction()
        {
        }

        public void Call()
        {
        }
    }
}
