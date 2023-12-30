using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Allegory.StockManagement.Customers;

public interface ICustomerRepository : IBasicRepository<Customer, Guid>
{
    Task<Customer?> FindByCodeAsync(string code, CancellationToken cancellationToken = default);
}