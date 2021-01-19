using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mainMenuActions = MainMenuFactory.GetMainMenuActions();
            mainMenuActions.PrintActionsAndCall();
        }
    }
}
