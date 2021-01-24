using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Threading;

namespace PointOfSale.Presentation.Actions.CategoryActions
{
    public class CategoryReviewAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ItemRepository _itemRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly RentRepository _rentRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Overview of offers in categories";

        public CategoryReviewAction(CategoryRepository categoryRepository, ItemRepository itemRepository,
            ServiceRepository serviceRepository, RentRepository rentRepository)
        {
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _serviceRepository = serviceRepository;
            _rentRepository = rentRepository;
        }


        public void Call()
        {
            var categories = _categoryRepository.AllCategories();

            foreach (var category in categories)
            {
                Console.WriteLine("\t \t " + category.NameOfCategory.ToUpper());

                var items = _itemRepository.AllItemsWithCategory(category);
                var services = _serviceRepository.AllServicesWithCategory(category);
                var rents = _rentRepository.AllRentsWithCategory(category);

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
