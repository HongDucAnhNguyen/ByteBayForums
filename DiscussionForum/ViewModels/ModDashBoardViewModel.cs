using DiscussionForum.Models;

namespace DiscussionForum.ViewModels
{
    public class ModDashBoardViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
