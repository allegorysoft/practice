using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Allegory.SampleApp.Products;

public interface IProductAppService : IApplicationService
{
    bool IsUow();
    bool VirtualIsUow();
    Task<bool> IsUowAsync();
    Task<bool> VirtualIsUowAsync();
}
