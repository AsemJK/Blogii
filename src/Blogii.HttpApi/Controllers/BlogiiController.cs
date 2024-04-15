using Blogii.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Blogii.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlogiiController : AbpControllerBase
{
    protected BlogiiController()
    {
        LocalizationResource = typeof(BlogiiResource);
    }
}
