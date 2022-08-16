using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Allegory.Module.Authorization;

public class FullNameClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
{
    public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        var identity = context.ClaimsPrincipal.Identities.FirstOrDefault();
        var name = identity?.FindFirst(AbpClaimTypes.Name)?.Value;
        var surname = identity?.FindFirst(AbpClaimTypes.SurName)?.Value;

        if (!name.IsNullOrEmpty() || !surname.IsNullOrEmpty())
        {
            string fullName = name + " " + surname;
            identity.AddClaim(new Claim("FullName", fullName));
        }

        await Task.CompletedTask;
    }
}
