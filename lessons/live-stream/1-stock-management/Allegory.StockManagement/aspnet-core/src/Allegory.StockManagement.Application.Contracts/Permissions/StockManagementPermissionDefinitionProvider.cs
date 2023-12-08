using Allegory.StockManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.StockManagement.Permissions;

public class StockManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StockManagementPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StockManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StockManagementResource>(name);
    }
}
