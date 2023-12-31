using System;
using Allegory.StockManagement.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Localization;

namespace Allegory.StockManagement;

public class CodeAlreadyExistsException : BusinessException, ILocalizeErrorMessage
{
    public Type EntityType { get;  }
    public string EntityCode { get; }

    public CodeAlreadyExistsException(Type entityType, string entityCode)
        : base(StockManagementErrorCodes.CodeAlreadyExists)
    {
        EntityType = entityType;
        EntityCode = entityCode;
    }

    public string LocalizeMessage(LocalizationContext context)
    {
        var localizer = context.LocalizerFactory.Create<StockManagementResource>();

        Data["EntityCode"] = EntityCode;
        Data["EntityType"] = localizer[EntityType.FullName!].Value;

        return localizer[Code!, Data["EntityType"], Data["EntityCode"]];
    }
}