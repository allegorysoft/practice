﻿using System.Threading.Tasks;

namespace Allegory.SampleMongoApp.OptionsPattern;

public class IntegrationAppService : SampleMongoAppAppService
{
    protected virtual IIntegrationService IntegrationService { get; }

    public IntegrationAppService(IIntegrationService integrationService)
    {
        IntegrationService = integrationService;
    }

    public virtual async Task DoAsync()
    {
        await IntegrationService.DoAsync();
    }
}