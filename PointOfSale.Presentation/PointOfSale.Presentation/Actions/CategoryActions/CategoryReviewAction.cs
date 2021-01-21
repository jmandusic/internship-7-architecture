using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Actions.CategoryActions
{
    public class CategoryReviewAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Overview of offers in categories";

        public CategoryReviewAction(CategoryRepository categoryRepository, OfferRepository offerRepository)
        {
            _categoryRepository = categoryRepository;
            _offerRepository = offerRepository;
        }


        public void Call()
        {
            var categories = _categoryRepository.AllCategories();

            foreach (var category in categories)
            {
                Console.WriteLine("\t \t " + category.NameOfCategory.ToUpper());

                var items = _offerRepository.AllItemsWithCategory(category);
                var services = _offerRepository.AllServicesWithCategory(category);
                var rents = _offerRepository.AllRentsWithCategory(category);

                PrintHelper.OffersPrint(items, services, rents);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key and enter to exit");
            Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
