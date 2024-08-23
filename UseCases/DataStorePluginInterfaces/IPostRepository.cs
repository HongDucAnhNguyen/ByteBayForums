using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IPostRepository
    {


        IEnumerable<Post> GetPosts(bool loadByCategory);
        void UpdatePost(int postId, Post postUpdateData);
        Post? GetPostById(int postId, bool loadByCategory);
        void DeletePost(int PostId);
        void AddPost(Post newPost);

        IEnumerable<Post> GetPostsByCategoryId(int categoryId);


    }



}
