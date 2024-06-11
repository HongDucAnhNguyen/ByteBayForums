using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        //data annotations
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
