using Volo.Abp.Reflection;

namespace Allegory.Module.Permissions;

public class ModulePermissions
{
    public const string GroupName = "Module";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ModulePermissions));
    }
}
