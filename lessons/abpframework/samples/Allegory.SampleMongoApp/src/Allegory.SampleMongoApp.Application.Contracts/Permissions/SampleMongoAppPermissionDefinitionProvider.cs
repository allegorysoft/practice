using Allegory.SampleMongoApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.SampleMongoApp.Permissions;

public class SampleMongoAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SampleMongoAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SampleMongoAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SampleMongoAppResource>(name);
    }
}
