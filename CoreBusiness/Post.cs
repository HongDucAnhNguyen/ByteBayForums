using CoreBusiness.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Post
    {
        //user thread post
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        public bool? IsArchived { get; set; }
        //also needs to relate to a userid as an author
        //also needs to have comments
        //also needs to have up and down votes

        public PostFlags Flag { get; set; }

        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime Created { get; set; }
        public Category? Category { get; set; }
    }
}
