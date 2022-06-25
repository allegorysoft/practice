using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Allegory.Module.Customers;

public interface ICustomerRepository : IBasicRepository<Customer, Guid>
{
    Task<long> GetCountAsync(
        Guid? customerGroupId = null,
        Guid? excludeCustomerId = null,
        CancellationToken cancellationToken = default);
}
