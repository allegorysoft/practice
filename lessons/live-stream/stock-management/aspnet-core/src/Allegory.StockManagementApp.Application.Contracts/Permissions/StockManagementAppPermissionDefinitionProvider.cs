using Allegory.StockManagementApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.StockManagementApp.Permissions;

public class StockManagementAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StockManagementAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StockManagementAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StockManagementAppResource>(name);
    }
}
