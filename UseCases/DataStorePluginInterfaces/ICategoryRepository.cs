using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        void UpdateCategory(int categoryId, Category categoryUpdateData);
        Category? GetCategoryById(int categoryId);
        void DeleteCategory(int categoryId);
        void AddCategory(Category newCategory);
    }
}