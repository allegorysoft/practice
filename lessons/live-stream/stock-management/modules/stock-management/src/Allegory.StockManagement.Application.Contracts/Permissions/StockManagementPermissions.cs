using Volo.Abp.Reflection;

namespace Allegory.StockManagement.Permissions;

public class StockManagementPermissions
{
    public const string GroupName = "StockManagement";

    public static class Products
    {
        public const string Default = GroupName + ".Products";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(StockManagementPermissions));
    }
}
