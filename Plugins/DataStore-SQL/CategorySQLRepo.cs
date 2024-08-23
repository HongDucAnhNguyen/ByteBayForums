using CoreBusiness;

using UseCases.DataStorePluginInterfaces;

namespace DataStore_SQL
{
    public class CategorySQLRepo : ICategoryRepository
    {
        private readonly ByteBayForumsContext _dbContext;
        public CategorySQLRepo(ByteBayForumsContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public void AddCategory(Category newCategory)
        {
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();



        }

        public void DeleteCategory(int categoryId)
        {



            var categoryRetrieved = GetCategoryById(categoryId);

            if (categoryRetrieved == null)
            {
                return;
            }
            _dbContext.Categories.Remove(categoryRetrieved);
            _dbContext.SaveChanges();

        }

        public IEnumerable<Category> GetCategories()
        {

            return _dbContext.Categories.ToList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Find(categoryId);

        }

        public void UpdateCategory(int categoryId, Category categoryUpdateData)
        {

            //in case somehow the args are not right
            if (categoryId != categoryUpdateData.CategoryId)
            {
                return;
            }


            var categoryRetrieved = GetCategoryById(categoryId);

            if (categoryRetrieved == null)
            {
                return;
            }



            //update category
            categoryRetrieved.Name = categoryUpdateData.Name;
            categoryRetrieved.Description = categoryUpdateData.Description;
            _dbContext.SaveChanges();

        }
    }
}
