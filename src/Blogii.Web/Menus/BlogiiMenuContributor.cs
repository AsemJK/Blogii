using Blogii.Localization;
using Blogii.MultiTenancy;
using Blogii.Permissions;
using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Blogii.Web.Menus;

public class BlogiiMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<BlogiiResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BlogiiMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        administration.AddItem(
            new ApplicationMenuItem(
                "Blogii.Cms",
                l["Menu:Cms"],
                url: "/cms/pages",
                icon: "fas fa-blog",
                order: 1,
                requiredPermissionName: BlogiiPermissions.Cms.Default
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
