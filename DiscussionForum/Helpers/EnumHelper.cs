using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DiscussionForum.Helpers
{
    public class EnumHelper
    {
        public static List<SelectListItem> GetSelectList<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = e.ToString(),
                           Text = GetDisplayName(e)
                       })
                       .ToList();
        }

        private static string GetDisplayName<TEnum>(TEnum value) where TEnum : Enum
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            return attribute != null ? attribute.Name : value.ToString();
        }
    }
}
