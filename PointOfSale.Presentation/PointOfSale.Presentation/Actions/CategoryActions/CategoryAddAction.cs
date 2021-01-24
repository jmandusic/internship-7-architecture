using PointOfSale.Data.Entities.Models;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Helpers;
using System;
using System.Threading;

namespace PointOfSale.Presentation.Actions.CategoryActions
{
    public class CategoryAddAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Add category";

        public CategoryAddAction(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public void Call()
        {
            var category = new Category();

            Console.WriteLine("Choose category name:");
            category.NameOfCategory = ReadHelper.LineInputCheck();

            Console.WriteLine(_categoryRepository.CategoryAdd(category));

            Thread.Sleep(1000);
            Console.Clear();
            return;
        }
    }
}
