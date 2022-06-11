using Allegory.SampleApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.SampleApp.Permissions;

public class SampleAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SampleAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SampleAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SampleAppResource>(name);
    }
}
