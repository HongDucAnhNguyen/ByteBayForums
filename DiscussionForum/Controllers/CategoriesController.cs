using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
namespace DiscussionForum.Controllers
{

    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IAddCategoryUseCase addCategoryUseCase;

        public CategoriesController(
            IViewCategoriesUseCase viewCategoriesUseCase,
            IAddCategoryUseCase addCategoryUseCase
            )
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.addCategoryUseCase = addCategoryUseCase;


        }

        //action methods

        //display categories
        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();

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
                addCategoryUseCase.Execute(category);
            }

            return View(category);
        }
    }
}
