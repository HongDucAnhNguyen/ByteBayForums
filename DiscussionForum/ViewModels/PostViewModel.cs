using DiscussionForum.Models;

//this class structures the forms to match the desired custom interface
//by using the corresponding model

namespace DiscussionForum.ViewModels
{
	public class PostViewModel
	{
		public Post PostObject { get; set; } = new Post();

		//categories list for post edit page, users can edit post content and chose to reassign
		//the post category
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
	}
}
