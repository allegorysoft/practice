using Allegory.NgSampleApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.NgSampleApp.Permissions;

public class NgSampleAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NgSampleAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NgSampleAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NgSampleAppResource>(name);
    }
}
