using DiscussionForum.Enums;
using DiscussionForum.Models;
using DiscussionForum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DiscussionForum.Controllers
{
    [Authorize]
    public class ModDashBoardController : Controller
    {
        private readonly ILogger<ModDashBoardController> _logger;

        public ModDashBoardController(ILogger<ModDashBoardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var modDashBoardViewModel = new ModDashBoardViewModel
            {


                Categories = CategoriesRepository.GetCategories()
            };


            return View(modDashBoardViewModel);
        }




        public IActionResult PostsByCategory(int categoryId)
        {
            var posts = PostRepository.GetPostsByCategoryId(categoryId);
            //this doesn't cost another request
            return PartialView("_ModDashBoardPosts", posts);
        }

        public IActionResult DashBoardPostDetail(int postId)
        {
            var post = PostRepository.GetPostById(postId);
            //this doesn't cost another request
            return PartialView("_ModDashBoardPostDetail", post);
        }


        public IActionResult Archive(int? id)
        {

            PostRepository.ArchivePost(id.HasValue ? id.Value : 0);

            return Redirect("/posts");


        }

        public IActionResult FlagPost(int? id)
        {


            var flagPostViewModel = new FlagPostViewModel
            {
                PostObject = PostRepository.GetPostById(id.HasValue ? id.Value : 0, loadCategory: true)
                ?? new Post(),
                SelectedFlag = PostFlags.None
            };


            return View(flagPostViewModel);
        }


        [HttpPost]
        [DisplayName("flag_post")]
        public IActionResult FlagPost(FlagPostViewModel model)
        {

            if (ModelState.IsValid)
            {
                PostRepository.FlagPost(model);

                return Redirect("/posts");



            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        _logger.LogWarning("Key: {Key}, Error: {ErrorMessage}", key, error.ErrorMessage);
                        if (error.Exception != null)
                        {
                            _logger.LogWarning("Exception: {Exception}", error.Exception);
                        }
                    }
                }
            }


            return View(model);





        }
    }
}
