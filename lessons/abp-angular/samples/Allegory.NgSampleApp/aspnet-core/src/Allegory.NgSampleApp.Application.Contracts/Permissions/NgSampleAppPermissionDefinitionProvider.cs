using Allegory.NgSampleApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.NgSampleApp.Permissions;

public class NgSampleAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var ngSampleAppGroup = context.AddGroup(NgSampleAppPermissions.GroupName, L("Permission:NgSampleApp"));

        var customersPermission = ngSampleAppGroup.AddPermission(NgSampleAppPermissions.Customers.Default, L("Permission:Customers"));
        customersPermission.AddChild(NgSampleAppPermissions.Customers.Create, L("Permission:Create"));
        customersPermission.AddChild(NgSampleAppPermissions.Customers.Edit, L("Permission:Edit"));
        customersPermission.AddChild(NgSampleAppPermissions.Customers.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NgSampleAppResource>(name);
    }
}
