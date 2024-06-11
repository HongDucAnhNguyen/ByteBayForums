using DiscussionForum.Models;
using DiscussionForum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            var posts = PostRepository.GetPosts(loadCategory: true);
            return View(posts);
        }


        public IActionResult Edit(int? id)
        {
            ViewBag.action = "edit";
            var postViewModel = new PostViewModel

            {
                Categories = CategoriesRepository.GetCategories(),
                PostObject = PostRepository.GetPostById(id.HasValue ? id.Value : 0, loadCategory: true)
                ?? new Post()
            };
            return View(postViewModel);
        }

        public IActionResult Add()
        {
            ViewBag.action = "add";
            var postViewModel = new PostViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(postViewModel);
        }

        public IActionResult Delete(int? id)
        {

            PostRepository.DeletePost(id.HasValue ? id.Value : 0);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(PostViewModel postUpdateData)
        {
            if (ModelState.IsValid)
            {
                PostRepository.UpdatePost(postUpdateData.PostObject.PostId, postUpdateData.PostObject);
                return RedirectToAction(nameof(Index));
            }
            return View(postUpdateData);
        }


        [HttpPost]
        public IActionResult Add(PostViewModel newPostData)
        {
            if (ModelState.IsValid)
            {
                PostRepository.AddPost(newPostData.PostObject);
                return RedirectToAction(nameof(Index));

            }
            newPostData.Categories = CategoriesRepository.GetCategories();
            return View(newPostData);
        }




    }
}
