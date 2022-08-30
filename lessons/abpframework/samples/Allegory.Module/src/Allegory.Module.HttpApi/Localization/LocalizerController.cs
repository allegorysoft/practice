using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Localization;

namespace Allegory.Module.Localization;

[RemoteService(Name = ModuleRemoteServiceConsts.RemoteServiceName)]
[Area(ModuleRemoteServiceConsts.ModuleName)]
[Route("api/module/localizer")]
public class LocalizerController : ModuleController
{
    [HttpGet]
    public IActionResult Localize(string key)
    {
        //var localizer = LazyServiceProvider.LazyGetRequiredService<IStringLocalizer<ModuleResource>>();
        //var localizer = StringLocalizerFactory.Create<IStringLocalizer<ModuleResource>>();
        //var defaultLocalizer = StringLocalizerFactory.CreateDefaultOrNull();

        var result = L[key];

        return Ok(result);
    }
}
