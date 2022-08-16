using Allegory.Module.Permissions;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Allegory.Module.Customers;

public class CrudCustomerGroupAppService
    : CrudAppService<
        CustomerGroup,
        CustomerGroupDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CustomerGroupCreateUpdateDto>,
    ICrudCustomerGroupAppService
{
    protected CustomerManager CustomerManager { get; }

    public CrudCustomerGroupAppService(
        IRepository<CustomerGroup, Guid> repository,
        CustomerManager customerManager)
        : base(repository)
    {
        CustomerManager = customerManager;

        GetPolicyName = ModulePermissions.CustomerGroups.Default;
        GetListPolicyName = ModulePermissions.CustomerGroups.Default;
        CreatePolicyName = ModulePermissions.CustomerGroups.Create;
        UpdatePolicyName = ModulePermissions.CustomerGroups.Update;
        DeletePolicyName = ModulePermissions.CustomerGroups.Delete;
    }

    [RemoteService(IsMetadataEnabled = false)]
    public async override Task<CustomerGroupDto> UpdateAsync(Guid id, CustomerGroupCreateUpdateDto input)
    {
        await CheckUpdatePolicyAsync();

        var customerGroup = await Repository.GetAsync(id);

        if (customerGroup.Code != input.Code)
            await CustomerManager.ChangeCustomerGroupCodeAsync(customerGroup, input.Code);
        customerGroup.SetDescription(input.Description);

        await Repository.UpdateAsync(customerGroup);

        return ObjectMapper.Map<CustomerGroup, CustomerGroupDto>(customerGroup);
    }

    [RemoteService(IsEnabled = false)]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }
}
