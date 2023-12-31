using Allegory.StockManagement.Customers;
using Allegory.StockManagement.Products;
using AutoMapper;

namespace Allegory.StockManagement;

public class StockManagementApplicationAutoMapperProfile : Profile
{
    public StockManagementApplicationAutoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>();

        CreateMap<Product, ProductDto>();
    }
}
