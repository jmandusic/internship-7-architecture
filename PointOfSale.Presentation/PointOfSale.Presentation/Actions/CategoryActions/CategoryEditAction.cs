﻿using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using PointOfSale.Domain.Enums;
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
    public class CategoryEditAction : IAction
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly OfferRepository _offerRepository;

        public int MenuIndex { get; set; }
        public string Label { get; set; } = "Edit category";

        public CategoryEditAction(CategoryRepository categoryRepository, OfferRepository offerRepository)
        {
            _categoryRepository = categoryRepository;
            _offerRepository = offerRepository;
        }


        public void Call()
        {
            var category = new Category();
            var categories = _categoryRepository.AllCategories();
            Console.WriteLine("Enter Id of category you want to edit");
            PrintHelper.CategoriesPrint(categories);
            var categoryId = ReadHelper.InputNumberCheck();
            try
            {
                category = categories.First(c => c.Id == categoryId);
            }
            catch
            {
                Console.WriteLine(ResponseResultType.NotFound);
                return;
            }

            var isOptionChosen = false;
            while (!isOptionChosen)
            {
                switch (HelpFunctions.ChooseOptionToEditCategory())
                {
                    case 1:
                        EditCategoryName(category);
                        isOptionChosen = true;
                        break;
                    case 2:
                        AddOfferToCategory(category);
                        isOptionChosen = true;
                        break;
                    case 3:
                        RemoveOfferFromCategory(category);
                        isOptionChosen = true;
                        break;
                    default:
                        Console.WriteLine("Undefined option, try again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
            Thread.Sleep(1500);
            Console.Clear();
            return;
        }

        public void EditCategoryName(Category category)
        {
            var categories = _categoryRepository.AllCategories();
            var editCategory = categories.First(c => c.Id == category.Id);

            Console.WriteLine("Press enter to skip edit");
            Console.WriteLine($"Name: ({category.NameOfCategory})");
            editCategory.NameOfCategory = ReadHelper.TryReadLineIfNotEmpty(out var name)
                ? name
                : category.NameOfCategory;

            Console.WriteLine(_categoryRepository.CategoryEditName(category));
        }

        public void AddOfferToCategory(Category category)
        {
            var offerCategories = _categoryRepository.GetOffersFromCategory(category);

            var itemsWithoutCategory = _offerRepository.ItemsWithoutCategory(_offerRepository.AllItems(),
                _offerRepository.AllItemsWithCategory(category));

            var servicesWithoutCategory = _offerRepository.ServicessWithoutCategory(_offerRepository.AllServices(),
                _offerRepository.AllServicesWithCategory(category));

            var rentsWithoutCategory = _offerRepository.RentsWithoutCategory(_offerRepository.AllRents(),
                _offerRepository.AllRentsWithCategory(category));

            PrintHelper.OffersPrint(itemsWithoutCategory, servicesWithoutCategory, rentsWithoutCategory);
            Console.WriteLine("These are all offers that are not in " + category.NameOfCategory);

            Console.WriteLine("To see all offers in the store enter 1 or press enter to continue");
            if (ReadHelper.TryReadLineIfNotEmpty(out var option) && option == "1")
            {
                PrintHelper.OffersPrint(_offerRepository.AllItems(),
                    _offerRepository.AllServices(), _offerRepository.AllRents());
                Console.WriteLine();
            }

            Console.WriteLine("Enter Id of offer you want to add to " + category.NameOfCategory);
            var index = ReadHelper.InputNumberCheck();
            Console.WriteLine();

            Console.WriteLine(_categoryRepository.AddOfferToCategory(category.Id, index));
        }

        public void RemoveOfferFromCategory(Category category)
        {
            var offerCategories = _categoryRepository.GetOffersFromCategory(category);

            if (offerCategories.Count == 0)
            {
                Console.WriteLine(category.NameOfCategory + " doesn't have any offers");
                Thread.Sleep(1000);
                return;
            }

            var items = _offerRepository.AllItemsWithCategory(category);
            var services = _offerRepository.AllServicesWithCategory(category);
            var rents = _offerRepository.AllRentsWithCategory(category);

            PrintHelper.OffersPrint(items, services, rents);

            Console.WriteLine("Enter Id of offer you want to remove from " + category.NameOfCategory);
            var index = ReadHelper.InputNumberCheck();
            Console.WriteLine();

            try
            {
                var removeOfferFromCategory = offerCategories.First(oc => oc.OfferId == index);
                Console.WriteLine(_categoryRepository.DeleteOfferFromCategory(category.Id, removeOfferFromCategory.OfferId));
            }
            catch
            {
                Console.WriteLine(ResponseResultType.NotFound);
            }
        }
    }
}

