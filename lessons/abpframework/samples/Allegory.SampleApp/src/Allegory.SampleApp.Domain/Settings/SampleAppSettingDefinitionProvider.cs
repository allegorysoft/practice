using Volo.Abp.Settings;

namespace Allegory.SampleApp.Settings;

public class SampleAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SampleAppSettings.MySetting1));
    }
}
