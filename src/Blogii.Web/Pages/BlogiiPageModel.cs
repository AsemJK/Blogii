using Blogii.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Blogii.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BlogiiPageModel : AbpPageModel
{
    protected BlogiiPageModel()
    {
        LocalizationResourceType = typeof(BlogiiResource);
    }
}
