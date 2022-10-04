using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Allegory.SampleApp.Products;

public class ProductManager : DomainService
{
    public IUnitOfWorkManager UnitOfWorkManager { get; }
    protected IUnitOfWork CurrentUnitOfWork => UnitOfWorkManager?.Current;

    public ProductManager(IUnitOfWorkManager unitOfWorkManager)
    {
        UnitOfWorkManager = unitOfWorkManager;
    }

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

    [UnitOfWork(true)]
    public virtual async Task<bool> UowAttributeAsync()
    {
        var isTransactional = CurrentUnitOfWork.Options.IsTransactional;
        return !await Task.FromResult(CurrentUnitOfWork == null);
    }
}
