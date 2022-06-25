using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Allegory.Module.Customers;

public interface ICustomerGroupRepository : IBasicRepository<CustomerGroup, Guid>
{
    Task<CustomerGroup> FindByCodeAsync(
        string code,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);
}
