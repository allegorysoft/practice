using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Allegory.Module.Web.Menus;

public class ModuleMenuContributor : IMenuContributor
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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ModuleMenus.Prefix, displayName: "Module", "~/Module", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
