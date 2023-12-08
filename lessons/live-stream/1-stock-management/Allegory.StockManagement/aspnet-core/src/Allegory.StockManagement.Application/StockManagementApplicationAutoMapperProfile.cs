using Allegory.StockManagement.Customers;
using AutoMapper;

namespace Allegory.StockManagement;

public class StockManagementApplicationAutoMapperProfile : Profile
{
    public StockManagementApplicationAutoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>();
    }
}
