using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
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

    [HttpGet("all-strings")]
    public IActionResult GetAllStrings(bool includeParentCulture, bool includeBaseLocalizers)
    {
        var result = L.GetAllStrings(includeParentCulture, includeBaseLocalizers, true);

        return Ok(result);
    }

    [HttpGet("localize-all-language")]
    public IActionResult LocalizeAllLanguage(string key)
    {
        var localizeOption = LazyServiceProvider.LazyGetRequiredService<IOptions<AbpLocalizationOptions>>().Value;

        List<(string culture, string localizedText)> values = new();

        foreach (var language in localizeOption.Languages)
            using (CultureHelper.Use(language.CultureName))
                values.Add((language.CultureName, L[key]));

        return Ok(
            values.Select(v => new
            {
                culture = v.culture,
                value = v.localizedText
            }).ToList());
    }
}
