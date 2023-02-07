using Volo.Abp.Reflection;

namespace Allegory.NgSampleModule.Permissions;

public class NgSampleModulePermissions
{
    public const string GroupName = "NgSampleModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(NgSampleModulePermissions));
    }
}
