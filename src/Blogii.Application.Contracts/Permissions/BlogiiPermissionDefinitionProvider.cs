using Blogii.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Blogii.Permissions;

public class BlogiiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BlogiiPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlogiiPermissions.MyPermission1, L("Permission:MyPermission1"));

        var cms = myGroup.AddPermission(BlogiiPermissions.Cms.Default, L("Permission:Cms"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogiiResource>(name);
    }
}
