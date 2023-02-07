using Allegory.NgSampleModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.NgSampleModule.Permissions;

public class NgSampleModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NgSampleModulePermissions.GroupName, L("Permission:NgSampleModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NgSampleModuleResource>(name);
    }
}
