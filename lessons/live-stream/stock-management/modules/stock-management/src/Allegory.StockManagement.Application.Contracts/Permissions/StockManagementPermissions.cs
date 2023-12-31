using Volo.Abp.Reflection;

namespace Allegory.StockManagement.Permissions;

public class StockManagementPermissions
{
    public const string GroupName = "StockManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(StockManagementPermissions));
    }
}
