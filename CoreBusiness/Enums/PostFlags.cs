using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Enums
{
    public enum PostFlags
    {
        //flags that mods or users can use
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Off Topic")]
        OffTopic = 1,
        [Display(Name = "Sensitive")]
        Sensitive = 2,
        [Display(Name = "Spam")]
        Spam = 3,
        [Display(Name = "Guideline Violation")]
        GuidelineViolation = 4
    }
}
