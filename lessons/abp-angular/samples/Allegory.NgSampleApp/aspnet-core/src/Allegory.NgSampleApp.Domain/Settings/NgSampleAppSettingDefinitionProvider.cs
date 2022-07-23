using Volo.Abp.Settings;

namespace Allegory.NgSampleApp.Settings;

public class NgSampleAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NgSampleAppSettings.MySetting1));
    }
}
