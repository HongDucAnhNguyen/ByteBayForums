using DiscussionForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class CategoriesController : Controller
    {

        //action methods

        //display categories
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();

            return View(categories);
        }


        //get edit page
        public IActionResult Edit(int? id)
        {

            ViewBag.Action = "edit";

            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);


            return View(category);


        }


        public IActionResult Add()
        {

            ViewBag.Action = "add";
            return View();
        }


        public IActionResult Delete(int? id)
        {

            CategoriesRepository.DeleteCategory(id.HasValue ? id.Value : 0);
            return RedirectToAction(nameof(Index));
        }



        //post edit request
        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {

                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);




        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}
