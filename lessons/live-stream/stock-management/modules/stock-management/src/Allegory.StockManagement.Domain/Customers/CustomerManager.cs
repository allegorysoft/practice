using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Allegory.StockManagement.Customers;

public class CustomerManager : DomainService
{
    public ICustomerRepository CustomerRepository { get; }

    public CustomerManager(ICustomerRepository customerRepository)
    {
        CustomerRepository = customerRepository;
    }

    public async Task<Customer> CreateAsync(string code)
    {
        var existingCustomer = await CustomerRepository.FindByCodeAsync(code);

        if (existingCustomer != null)
        {
            throw new BusinessException(StockManagementErrorCodes.CustomerCodeAlreadyExists)
                .WithData("CustomerCode", code);
        }

        return new Customer(GuidGenerator.Create(), code);
    }
}