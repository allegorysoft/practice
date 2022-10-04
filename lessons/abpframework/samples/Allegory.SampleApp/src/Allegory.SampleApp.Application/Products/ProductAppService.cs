using System;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace Allegory.SampleApp.Products;

public class ProductAppService : SampleAppAppService, IProductAppService
{
    public bool IsUow()
    {
        return !(CurrentUnitOfWork == null);
    }

    public virtual bool VirtualIsUow()
    {
        return !(CurrentUnitOfWork == null);
    }

    public async Task<bool> IsUowAsync()
    {
        return !await Task.FromResult(CurrentUnitOfWork == null);
    }

    public virtual async Task<bool> VirtualIsUowAsync()
    {
        return !await Task.FromResult(CurrentUnitOfWork == null);
    }

    public virtual async Task CreateRoleAsync()
    {
        var roleAppService = LazyServiceProvider.LazyGetRequiredService<IIdentityRoleAppService>();

        using (var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
        {
            await roleAppService.CreateAsync(new IdentityRoleCreateDto
            {
                Name = "Role-With-Exception"
            });

            await uow.CompleteAsync();
        }

        throw new Exception();
    }
}
