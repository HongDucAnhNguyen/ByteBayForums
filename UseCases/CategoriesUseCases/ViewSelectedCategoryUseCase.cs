﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewSelectedCategoryUseCase : ISelectCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {

            this.categoryRepository = categoryRepository;

        }

        public Category? Execute(int categoryId)
        {


            return categoryRepository.GetCategoryById(categoryId);

        }

    }
}
