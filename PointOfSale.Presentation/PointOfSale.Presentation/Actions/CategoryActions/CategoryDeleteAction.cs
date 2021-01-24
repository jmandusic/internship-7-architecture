using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Threading;

namespace PointOfSale.Presentation.Actions.CategoryActions
{
    public class CategoryDeleteAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Delete category";

        public CategoryDeleteAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public void Call()
        {
            PrintHelper.CategoriesPrint(_categoryRepository.AllCategories());

            Console.WriteLine("Choose category Id you want to delete:");
            var index = ReadHelper.InputNumberCheck();

            Console.WriteLine(_categoryRepository.CategoryDelete(index));

            Thread.Sleep(1000);
            Console.Clear();
            return;
        }
    }
}
