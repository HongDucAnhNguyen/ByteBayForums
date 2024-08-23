﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
namespace DataStore_InMemory
{
    public class CategoriesInMemoryRepository : ICategoryRepository
    {

        private List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId = 1, Name = "Web Dev", Description="Web Development"},
            new Category {CategoryId = 2, Name="Embedded Systems", Description="Embedded Systems"},
            new Category {CategoryId = 3,Name="Cyber Security", Description="Cyber Security"}
        };

        public void AddCategory(Category category)
        {
            //get the value of the max Id number from among categories
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }


        public void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);

            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        public IEnumerable<Category> GetCategories()
        {

            return _categories;

        }

        public Category? GetCategoryById(int categoryId)
        {
            //first entity matching condition, or default of null
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category == null) return null;
            return new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };
        }

        public void UpdateCategory(int categoryId, Category categoryUpdateData)
        {
            if (categoryId != categoryUpdateData.CategoryId)
            {
                return;
            }
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = categoryUpdateData.Name;
                categoryToUpdate.Description = categoryUpdateData.Description;


            }
        }


    }
}
