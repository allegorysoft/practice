using System.Threading.Tasks;

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
}
