using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Allegory.StockManagement.Web.Menus;

public class StockManagementMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(StockManagementMenus.Prefix, displayName: "StockManagement", "~/StockManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
