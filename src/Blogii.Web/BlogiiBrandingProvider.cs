using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Blogii.Web;

[Dependency(ReplaceServices = true)]
public class BlogiiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Blogii";
}
