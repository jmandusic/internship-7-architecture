﻿using PointOfSale.Domain.Factories;
using PointOfSale.Domain.Repositories;
using PointOfSale.Presentation.Abstractions;
using PointOfSale.Presentation.Actions;
using PointOfSale.Presentation.Actions.CategoryActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Presentation.Factories
{
    public static class CategoryActionsFactory
    {
        public static CategoryParentAction GetCategoryParentAction()
        {
            var categoryActions = new List<IAction>
            {
                new CategoryAddAction(RepositoryFactory.GetRepository<CategoryRepository>()),
                new CategoryDeleteAction(RepositoryFactory.GetRepository<CategoryRepository>()),
                new CategoryReviewAction
                (
                    RepositoryFactory.GetRepository<CategoryRepository>(),
                    RepositoryFactory.GetRepository<ItemRepository>(),
                    RepositoryFactory.GetRepository<ServiceRepository>(),
                    RepositoryFactory.GetRepository<RentRepository>()
                ),
                new CategoryEditAction
                (
                    RepositoryFactory.GetRepository<CategoryRepository>(),
                    RepositoryFactory.GetRepository<ItemRepository>(),
                    RepositoryFactory.GetRepository<ServiceRepository>(),
                    RepositoryFactory.GetRepository<RentRepository>()
                ),
                new ExitMenuAction()
            };

            var categoryParentAction = new CategoryParentAction(categoryActions);
            return categoryParentAction;
        }
    }
}
