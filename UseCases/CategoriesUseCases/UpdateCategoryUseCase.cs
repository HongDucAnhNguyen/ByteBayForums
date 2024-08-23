using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{

    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;






        public UpdateCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

        }


        public void Execute(int categoryId, Category categoryUpdateData)
        {


            categoryRepository.UpdateCategory(categoryId, categoryUpdateData);

        }








    }
}
