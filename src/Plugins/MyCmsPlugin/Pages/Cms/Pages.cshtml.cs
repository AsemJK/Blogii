using Microsoft.AspNetCore.Authorization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MyCmsPlugin.Pages.Cms
{
    [Authorize]
    public class PagesModel : AbpPageModel
    {
        public void OnGet()
        {
        }
    }
}
