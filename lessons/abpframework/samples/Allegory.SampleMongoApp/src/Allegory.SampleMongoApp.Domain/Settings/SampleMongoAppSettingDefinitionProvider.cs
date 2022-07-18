using Volo.Abp.Settings;

namespace Allegory.SampleMongoApp.Settings;

public class SampleMongoAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SampleMongoAppSettings.MySetting1));
    }
}
