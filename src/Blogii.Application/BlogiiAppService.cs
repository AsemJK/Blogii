using System;
using System.Collections.Generic;
using System.Text;
using Blogii.Localization;
using Volo.Abp.Application.Services;

namespace Blogii;

/* Inherit your application services from this class.
 */
public abstract class BlogiiAppService : ApplicationService
{
    protected BlogiiAppService()
    {
        LocalizationResource = typeof(BlogiiResource);
    }
}
