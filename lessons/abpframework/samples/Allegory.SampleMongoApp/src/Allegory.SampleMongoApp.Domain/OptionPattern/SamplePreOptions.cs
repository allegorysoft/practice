using System;

namespace Allegory.SampleMongoApp.OptionPattern;

public class SamplePreOptions
{
    public string IntegrationService { get; set; }
    public bool DoOtherThings { get; set; }

    public Type GetIntegrationService()
    {
        var type =  typeof(XIntegrationService);

        if (!IntegrationService.IsNullOrWhiteSpace())
        {
            type = Type.GetType(IntegrationService) ?? type;
        }

        return type;
    }
}