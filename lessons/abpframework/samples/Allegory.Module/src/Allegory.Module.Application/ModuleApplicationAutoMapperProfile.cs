using Allegory.Module.Customers;
using AutoMapper;

namespace Allegory.Module;

public class ModuleApplicationAutoMapperProfile : Profile
{
    public ModuleApplicationAutoMapperProfile()
    {
        CreateMap<CustomerGroup, CustomerGroupDto>();
        //CreateMap<CustomerGroupCreateUpdateDto, CustomerGroup>(MemberList.Source);
    }
}
