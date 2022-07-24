using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Allegory.Module.Customers;

public class CustomerGroupAppService : ModuleAppService, ICustomerGroupAppService
{
    protected ICustomerGroupRepository CustomerGroupRepository { get; }
    protected CustomerManager CustomerManager { get; }

    public CustomerGroupAppService(
        ICustomerGroupRepository customerGroupRepository,
        CustomerManager customerManager)
    {
        CustomerGroupRepository = customerGroupRepository;
        CustomerManager = customerManager;
    }

    public virtual async Task<CustomerGroupDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(
            await CustomerGroupRepository.GetAsync(id)
        );
    }

    public virtual async Task<CustomerGroupDto> GetByCodeAsync(string code)
    {
        var customerGroup = await CustomerGroupRepository.FindByCodeAsync(code);

        if (customerGroup == null)
            throw new EntityNotFoundException($"{code} kodlu müşteri grubu bulunamadı");

        return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
    }

    public virtual async Task<PagedResultDto<CustomerGroupDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
            input.Sorting = nameof(CustomerGroup.Code);

        var result = await CustomerGroupRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting);

        var totalCount = await CustomerGroupRepository.GetCountAsync();

        return new PagedResultDto<CustomerGroupDto>(
            totalCount,
            ObjectMapper.Map<List<CustomerGroup>, List<CustomerGroupDto>>(result));
    }

    public virtual async Task<CustomerGroupDto> CreateAsync(CustomerGroupCreateUpdateDto input)
    {
        var customerGroup = await CustomerManager.CreateCustomerGroupAsync(
            input.Code,
            description: input.Description);

        await CustomerGroupRepository.InsertAsync(customerGroup);

        return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
    }

    public virtual async Task<CustomerGroupDto> UpdateAsync(
        Guid id,
        CustomerGroupCreateUpdateDto input)
    {
        var customerGroup = await CustomerGroupRepository.GetAsync(id);

        if (customerGroup.Code != input.Code)
            await CustomerManager.ChangeCustomerGroupCodeAsync(customerGroup, input.Code);
        customerGroup.SetDescription(input.Description);

        await CustomerGroupRepository.UpdateAsync(customerGroup);

        return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        //TODO  Check if customer is using
        await CustomerGroupRepository.DeleteAsync(id);
    }
}
