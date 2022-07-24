using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Allegory.Module.Customers;

public interface ICustomerRepository : IBasicRepository<Customer, Guid>
{
    Task<CustomerWithDetails> GetWithDetailsAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<Customer>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<long> GetCountAsync(
        string filter = null,
        Guid? customerGroupId = null,
        Guid? excludeCustomerId = null,
        CancellationToken cancellationToken = default);
}
