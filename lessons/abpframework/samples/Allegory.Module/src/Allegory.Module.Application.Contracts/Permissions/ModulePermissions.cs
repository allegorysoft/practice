using Volo.Abp.Reflection;

namespace Allegory.Module.Permissions;

public class ModulePermissions
{
    public const string GroupName = "Module";

    public static class CustomerGroups
    {
        public const string Default = GroupName + ".CustomerGroup";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class Customers
    {
        public const string Default = GroupName + ".Customer";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ModulePermissions));
    }
}
