using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Security.Claims;

namespace Allegory.Module.Authorization;

public class NameCheckPermissionValueProvider : PermissionValueProvider
{
    public override string Name => "CheckName";

    public NameCheckPermissionValueProvider(IPermissionStore permissionStore) : base(permissionStore)
    {

    }

    public async override Task<PermissionGrantResult> CheckAsync(PermissionValueCheckContext context)
    {
        return await CheckNameAsync(context.Principal?.FindFirst(AbpClaimTypes.Name)?.Value);
    }

    public async override Task<MultiplePermissionGrantResult> CheckAsync(PermissionValuesCheckContext context)
    {
        var permissionNames = context.Permissions.Select(x => x.Name).Distinct().ToArray();
        Check.NotNullOrEmpty(permissionNames, nameof(permissionNames));

        var result = await CheckNameAsync(context.Principal?.FindFirst(AbpClaimTypes.Name)?.Value);

        return new MultiplePermissionGrantResult(permissionNames, result);
    }

    protected virtual Task<PermissionGrantResult> CheckNameAsync(string name)
    {
        PermissionGrantResult permission;

        switch (name)
        {
            case "Ahmet":
                permission = PermissionGrantResult.Granted; break;
            case "Mehmet":
                permission = PermissionGrantResult.Prohibited; break;
            default:
                permission = PermissionGrantResult.Undefined; break;
        }

        return Task.FromResult(permission);
    }
}
