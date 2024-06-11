//in memory static data storage

using DiscussionForum.Enums;
using DiscussionForum.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DiscussionForum.Models
{
    public class PostRepository
    {

        private static List<Post> _posts = new List<Post>() {

             new Post { PostId = 1, CategoryId = 1, Subject = "Cloudinary API for NEXT.js", Content="How do I approach implementing cloudinary API into my profile section",
                 Flag = PostFlags.None },
            new Post { PostId = 2, CategoryId = 1, Subject = "ASP.Net",
                Content = "Is it true that dotnet developers make big bucks", Flag = PostFlags.None },
            new Post { PostId = 3, CategoryId = 2, Subject = "Road map for beginners",
                Content = "where do i start with embedded programming?", Flag = PostFlags.None },
            new Post { PostId = 4, CategoryId = 2, Subject = "Programming my STM32 Board",
                Content = "anyone knows a good source to get this microcontroller? Have been " +
                "searching around but no luck", Flag = PostFlags.None }

        };


        public static void AddPost(Post post)
        {
            var maxId = _posts.Max(x => x.PostId);
            post.PostId = maxId + 1;
            post.Created = DateTime.UtcNow;

            _posts.Add(post);
        }


        public static List<Post> GetPosts(bool loadCategory = false)
        {



            if (loadCategory == false)
            {

                return _posts;
            }

            else
            {
                if (_posts != null && _posts.Count > 0)
                {
                    _posts.ForEach(post =>
                    {
                        post.Category = CategoriesRepository.GetCategoryById(post.CategoryId.Value);
                    });

                }
                return _posts ?? new List<Post>();
            }

        }

        public static Post? GetPostById(int postId, bool loadCategory = false)
        {
            var postFound = _posts.FirstOrDefault(x => x.PostId == postId);
            if (postFound != null)
            {
                var post = new Post
                {
                    PostId = postFound.PostId,
                    Subject = postFound.Subject,
                    Content = postFound.Content,

                    CategoryId = postFound.CategoryId
                };


                if (loadCategory && post.CategoryId.HasValue)
                {
                    post.Category = CategoriesRepository.GetCategoryById(post.CategoryId.Value);
                }
                return post;

            }

            return null;
        }

        public static void UpdatePost(int postId, Post postUpdateData)
        {
            if (postId != postUpdateData.PostId) return;

            var postToUpdate = _posts.FirstOrDefault(x => x.PostId == postId);
            if (postToUpdate != null)
            {
                postToUpdate.Subject = postUpdateData.Subject;
                postToUpdate.Content = postUpdateData.Content;
                postToUpdate.CategoryId = postUpdateData.CategoryId;
            }
        }

        public static void DeletePost(int postId)
        {
            var postToDelete = _posts.FirstOrDefault(x => x.PostId == postId);
            if (postToDelete != null)
            {
                _posts.Remove(postToDelete);
            }
        }

        public static List<Post> GetPostsByCategoryId(int categoryId)
        {
            var postsByCategoryId = _posts.Where(x => x.CategoryId == categoryId);
            if (postsByCategoryId != null)
            {

                return postsByCategoryId.ToList();
            }
            else return new List<Post> { };
        }

        public static void ArchivePost(int postId)
        {
            var postFound = _posts.FirstOrDefault(x => x.PostId == postId);
            if (postFound != null)
            {

                postFound.IsArchived = true;
            }

        }

        public static void FlagPost(FlagPostViewModel model)
        {
            var postFound = _posts.FirstOrDefault(x => x.PostId ==
            model.PostObject.PostId);
            if (postFound != null)
            {

                postFound.Flag = model.SelectedFlag;

            }
        }


    }
}
