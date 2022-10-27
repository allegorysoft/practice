using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Allegory.SampleApp.Example;

public interface IExampleRepository : IRepository
{
    Task GetExecutionPerformance();
}
