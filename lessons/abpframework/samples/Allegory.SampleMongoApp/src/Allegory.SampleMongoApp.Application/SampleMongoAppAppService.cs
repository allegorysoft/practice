using System;
using System.Collections.Generic;
using System.Text;
using Allegory.SampleMongoApp.Localization;
using Volo.Abp.Application.Services;

namespace Allegory.SampleMongoApp;

/* Inherit your application services from this class.
 */
public abstract class SampleMongoAppAppService : ApplicationService
{
    protected SampleMongoAppAppService()
    {
        LocalizationResource = typeof(SampleMongoAppResource);
    }
}
