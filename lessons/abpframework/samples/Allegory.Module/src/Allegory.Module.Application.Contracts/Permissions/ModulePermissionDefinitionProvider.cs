using Allegory.Module.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.Module.Permissions;

public class ModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var moduleGroup = context.AddGroup(ModulePermissions.GroupName, L("Permission:Module"));

        var customerGroupsPermission = moduleGroup.AddPermission(ModulePermissions.CustomerGroups.Default, L("Permission:CustomerGroups"));
        customerGroupsPermission.AddChild(ModulePermissions.CustomerGroups.Create, L("Permission:Create"));
        customerGroupsPermission.AddChild(ModulePermissions.CustomerGroups.Update, L("Permission:Edit"));
        customerGroupsPermission.AddChild(ModulePermissions.CustomerGroups.Delete, L("Permission:Delete"));

        var customersPermission = moduleGroup.AddPermission(ModulePermissions.Customers.Default, L("Permission:Customers"));
        customersPermission.AddChild(ModulePermissions.Customers.Create, L("Permission:Create"));
        customersPermission.AddChild(ModulePermissions.Customers.Update, L("Permission:Edit"));
        customersPermission.AddChild(ModulePermissions.Customers.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ModuleResource>(name);
    }
}
