using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace DataStore_SQL
{
    public class PostSQLRepo : IPostRepository
    {

        private readonly ByteBayForumsContext _dbContext;
        private readonly CategorySQLRepo categorySQLRepo;

        public PostSQLRepo(ByteBayForumsContext _dbContext, CategorySQLRepo categorySQLRepo)
        {
            this._dbContext = _dbContext;
            this.categorySQLRepo = categorySQLRepo;
        }

        public void AddPost(Post newPost)
        {
            _dbContext.Posts.Add(newPost);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Post> GetPosts(bool loadCategory = false)
        {



            if (loadCategory == false)
            {

                return _dbContext.Posts.ToList();
            }

            else
            {
                var posts = _dbContext.Posts.ToList();
                if (posts != null && posts.Count > 0)
                {
                    posts.ForEach(post =>
                    {
                        post.Category = categorySQLRepo.GetCategoryById(post.CategoryId.Value);
                    });

                }
                return posts ?? new List<Post>();
            }

        }

        public Post? GetPostById(int postId, bool loadCategory = false)
        {

            var postFound = _dbContext.Posts.Find(postId);
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
                    post.Category = categorySQLRepo.GetCategoryById(post.CategoryId.Value);
                }
                return post;

            }

            return null;
        }

        public void UpdatePost(int postId, Post postUpdateData)
        {
            if (postId != postUpdateData.PostId) return;

            var postToUpdate = _dbContext.Posts.Find(postId);
            if (postToUpdate == null)
            {

                return;
            }
            postToUpdate.Subject = postUpdateData.Subject;
            postToUpdate.Content = postUpdateData.Content;
            postToUpdate.CategoryId = postUpdateData.CategoryId;
            _dbContext.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var postToDelete = _dbContext.Posts.Find(postId);
            if (postToDelete == null)
            {
                return;
            }

            _dbContext.Posts.Remove(postToDelete);
            _dbContext.SaveChanges();

        }

        public IEnumerable<Post> GetPostsByCategoryId(int categoryId)
        {
            return _dbContext.Posts.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
