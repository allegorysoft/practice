using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class CustomerAppService : ModuleAppService, ICustomerAppService
{
    /*                                 ****Best Practices****
     *  1 - ApplicationService'ler için interface oluştur ve implemente et(AppService son eki kullan)
     *  2 - BaseAppService'den kalıtım al 
     *  3 - Tanımlanan metotların input/output parametreleri için DTO kullan
     *  4 - Output DTO'ları ortak kullanmaya çalış(Basic ve Detailed DTO'lar oluştur)
     *  5 - Input DTO'ları ayrı kullanmaya çalış(CustomerCreateDto, CustomerUpdateDto gibi)
     *  6 - Input DTO'larında mapping kullanma
     *  7 - Metotları asenkron olarak tanımla ve sonuna "Async" ekini kullan
     *  8 - Metot isimlendirmelerini basit tut(GetCustomerAsync yerine GetAsync gibi)
     *  9 - Metotları "virtual" olarak tanımla
     * 10 - "private" olacak değişken/metotları "protected" olarak tanımla
     * 11 - Dönüş DTO'larında "Detailed" kullan(Performans'ın kritik olduğu yerlerde "Basic" kullanılabilir)
     * 12 - GenericRepository'ler yerine domain'e ait repository'ler tanımla ve kullan(IRepository<Customer,Guid> yerine ICustomerRepository)
     * 13 - Application ve Domain katmanlarında IQueryable istekler kullanmamaya çalış bunun yerine repository metotları tanımla ve kullan
     * 14 - Aynı modül veya uygulamadaki diğer ApplicationService'leri inject etme
     */

    protected ICustomerRepository CustomerRepository { get; }
    protected CustomerManager CustomerManager { get; }

    public CustomerAppService(
        ICustomerRepository customerRepository,
        CustomerManager customerManager)
    {
        CustomerRepository = customerRepository;
        CustomerManager = customerManager;
    }

    public virtual async Task<CustomerWithDetailsDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomerListDto input)
    {

        throw new NotImplementedException();
    }

    public virtual async Task<CustomerWithDetailsDto> CreateAsync(CustomerCreateDto input)
    {
        var customer = new Customer(
            GuidGenerator.Create(),
            input.Name,
            input.Surname);

        await SetCustomerBaseAsync(customer, input);

        //set create properties

        await CustomerRepository.InsertAsync(customer);

        var customerDto = ObjectMapper.Map<Customer, CustomerWithDetailsDto>(customer);
        customerDto.CustomerGroupCode = input.CustomerGroupCode;

        return customerDto;
    }

    public virtual async Task<CustomerWithDetailsDto> UpdateAsync(Guid id, CustomerUpdateDto input)
    {
        var customer = await CustomerRepository.GetAsync(id);

        customer.SetName(input.Name);
        customer.SetSurname(input.Surname);

        await SetCustomerBaseAsync(customer, input);

        //set update properties

        await CustomerRepository.UpdateAsync(customer);

        var customerDto = ObjectMapper.Map<Customer, CustomerWithDetailsDto>(customer);
        customerDto.CustomerGroupCode = input.CustomerGroupCode;

        return customerDto;
    }

    protected virtual async Task SetCustomerBaseAsync(
        Customer customer,
        CustomerCreateOrUpdateDtoBase input)
    {
        await CustomerManager.SetCustomerGroupAsync(customer, input.CustomerGroupCode);

        customer.Address = new Address(
            input.Address.Country,
            input.Address.City,
            input.Address.Town,
            input.Address.Line1,
            input.Address.Line2);

        await SetCustomerContactInformationAsync(
            customer,
            input.ContactInformations);
    }

    protected virtual async Task SetCustomerContactInformationAsync(
        Customer customer,
        ICollection<ContactInformationCreateUpdateDto> expectedContactInformations)
    {
        //delete
        customer.ContactInformations.RemoveAll(c => !expectedContactInformations.Any(e => e.Name == c.Name));

        //update
        foreach (var contactInformation in customer.ContactInformations)
        {
            var expectedContactInformation = expectedContactInformations.Single(e => e.Name == contactInformation.Name);

            contactInformation.Type = expectedContactInformation.Type;
            contactInformation.SetValue(expectedContactInformation.Value);
        }

        //create
        foreach (var contactInformation in expectedContactInformations.Where(c => !customer.ContactInformations.Any(e => e.Name == c.Name)))
        {
            var createdContactInformation = customer.AddContactInformation(
                contactInformation.Name,
                contactInformation.Type,
                contactInformation.Value);

            //set other contact information properties
        }

        await Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await CustomerRepository.DeleteAsync(id);
    }
}
