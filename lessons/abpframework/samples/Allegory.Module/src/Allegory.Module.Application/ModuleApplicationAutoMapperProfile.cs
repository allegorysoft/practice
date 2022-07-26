using Allegory.Module.Customers;
using AutoMapper;

namespace Allegory.Module;

public class ModuleApplicationAutoMapperProfile : Profile
{
    public ModuleApplicationAutoMapperProfile()
    {
        CreateMap<CustomerGroup, CustomerGroupDto>();
        CreateMap<CustomerGroupCreateUpdateDto, CustomerGroup>(MemberList.Source);

        #region Customer
        CreateMap<Customer, CustomerDto>(MemberList.Destination);
        CreateMap<Customer, CustomerWithDetailsDto>(MemberList.Destination)
            .ForMember(f => f.CustomerGroupCode, map => map.Ignore());
        CreateMap<ContactInformation, ContactInformationDto>(MemberList.Destination);
        CreateMap<Address, AddressDto>();
        CreateMap<CustomerWithDetails, CustomerWithDetailsDto>();
        #endregion
    }
}
