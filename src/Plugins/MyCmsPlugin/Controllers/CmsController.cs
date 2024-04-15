using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCmsPlugin.Data;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc;

namespace MyCmsPlugin.Controllers
{
    [Route("{slug}")]
    [Authorize]
    public class CmsController : AbpController
    {
        public CmsController(MyCmsPluginDbContextExtension dbContextExtension)
        {
            _dbContextExtension = dbContextExtension;
        }

        public MyCmsPluginDbContextExtension _dbContextExtension { get; }

        public IActionResult Index(string slug)
        {
            var page = _dbContextExtension.Pages.FirstOrDefault(p => p.Slug == slug);
            if (page == null)
            {
                return NotFound();
            }
            return View("~/Pages/PageContent.cshtml", page);
        }
    }
}
