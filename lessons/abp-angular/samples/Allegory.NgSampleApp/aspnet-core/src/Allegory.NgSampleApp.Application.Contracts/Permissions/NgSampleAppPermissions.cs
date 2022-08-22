using Volo.Abp.Reflection;
namespace Allegory.NgSampleApp.Permissions;

public static class NgSampleAppPermissions
{
    public const string GroupName = "NgSampleApp";

    public static class Customers
    {
        public const string Default = GroupName + ".Customers";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(NgSampleAppPermissions));
    }
}
