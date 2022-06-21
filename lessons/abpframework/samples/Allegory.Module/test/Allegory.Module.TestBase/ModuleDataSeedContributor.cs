using Allegory.Module.Customers;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Allegory.Module;

public class ModuleDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<Customer, Guid> _customerRepository;

    public ModuleDataSeedContributor(
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant,
        IRepository<Customer, Guid> customerRepository)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _customerRepository = customerRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            await CreateCustomers();
        }
    }
    async Task CreateCustomers()
    {
        var customer1 = new Customer(_guidGenerator.Create(), "Ali", "CAN");
        await _customerRepository.InsertAsync(customer1);

        var customer2 = new Customer(_guidGenerator.Create(), "Mehmet", "BERBER");
        await _customerRepository.InsertAsync(customer2);

        var customer3 = new Customer(_guidGenerator.Create(), "Ayşe", "KIRAN");
        await _customerRepository.InsertAsync(customer3);
    }
}
