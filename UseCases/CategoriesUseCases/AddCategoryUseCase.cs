using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {

        private readonly ICategoryRepository categoryRepository;


        //constructor dependency injection
        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {

            this.categoryRepository = categoryRepository;

        }



        //this represents the execution of a use case, this convention will repeat itself
        //through out the source code of this project
        public void Execute(Category newCategory)
        {

            categoryRepository.AddCategory(newCategory);

        }
    }
}
