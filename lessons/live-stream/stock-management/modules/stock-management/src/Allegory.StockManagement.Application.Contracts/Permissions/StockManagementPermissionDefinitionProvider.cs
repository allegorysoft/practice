using Allegory.StockManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.StockManagement.Permissions;

public class StockManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var stockManagementGroup = context.AddGroup(StockManagementPermissions.GroupName, L("Permission:StockManagement"));

        var productsPermission = stockManagementGroup.AddPermission(StockManagementPermissions.Products.Default, L("Permission:Products"));
        productsPermission.AddChild(StockManagementPermissions.Products.Create, L("Permission:Create"));
        productsPermission.AddChild(StockManagementPermissions.Products.Update, L("Permission:Update"));
        productsPermission.AddChild(StockManagementPermissions.Products.Delete, L("Permission:Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StockManagementResource>(name);
    }
}
