using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Allegory.NgSampleModule.Blazor.Menus;

public class NgSampleModuleMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(NgSampleModuleMenus.Prefix, displayName: "NgSampleModule", "/NgSampleModule", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
