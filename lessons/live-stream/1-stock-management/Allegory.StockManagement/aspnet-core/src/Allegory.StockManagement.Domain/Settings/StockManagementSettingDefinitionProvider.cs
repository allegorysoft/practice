using Volo.Abp.Settings;

namespace Allegory.StockManagement.Settings;

public class StockManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(StockManagementSettings.MySetting1));
    }
}
