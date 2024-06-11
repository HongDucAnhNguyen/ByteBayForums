
using DiscussionForum.Enums;
using DiscussionForum.Models;
using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.ViewModels
{
    public class FlagPostViewModel
    {
        public Post PostObject { get; set; } = new Post();

        public PostFlags SelectedFlag { get; set; }
    }
}
