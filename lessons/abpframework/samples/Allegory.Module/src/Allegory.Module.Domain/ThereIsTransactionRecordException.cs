using Allegory.Module.Localization;
using Microsoft.Extensions.Localization;
using System;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Localization;

namespace Allegory.Module;

public class ThereIsTransactionRecordException : BusinessException, ILocalizeErrorMessage
{
    public Type EntityType { get; set; }

    public ThereIsTransactionRecordException(Type entityType) : base(ModuleErrorCodes.ThereIsTransactionRecord)
    {
        EntityType = entityType;
    }

    public string LocalizeMessage(LocalizationContext context)
    {
        var localizer = context.LocalizerFactory.Create<ModuleResource>();

        Data["EntityType"] = localizer[EntityType.FullName].Value;

        return localizer[Code, Data["EntityType"]];
    }
}
