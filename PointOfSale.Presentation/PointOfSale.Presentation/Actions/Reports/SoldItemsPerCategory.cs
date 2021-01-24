using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using System;

namespace PointOfSale.Presentation.Actions.Reports
{
    public class SoldItemsPerCategory : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Sold items per category";

        public SoldItemsPerCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Call()
        {
            var soldItemsPerCategories = _categoryRepository.NumberOfSalesPerCategory();
            Console.WriteLine("\t \t CATEGORIES");
            foreach (var category in soldItemsPerCategories)
            {
                Console.WriteLine($"Name of category: {category.NameOfcategory}\nItems sold: {category.Sales}\n");
            }
            Console.ReadLine();
            Console.Clear();
        }

    }
}
