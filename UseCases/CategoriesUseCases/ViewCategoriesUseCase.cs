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
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {

        private readonly ICategoryRepository categoryRepository;


        //constructor dependency injection
        public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
        {

            this.categoryRepository = categoryRepository;

        }



        //this represents the execution of a use case, this convention will repeat itself
        //through out the source code of this project
        public IEnumerable<Category> Execute()
        {

            return categoryRepository.GetCategories();

        }
    }
}
