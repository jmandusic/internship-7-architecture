using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Factories;

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
