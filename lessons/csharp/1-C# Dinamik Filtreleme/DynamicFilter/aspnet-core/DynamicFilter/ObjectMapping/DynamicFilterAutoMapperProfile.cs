using AutoMapper;
using DynamicFilter.Entities;

namespace DynamicFilter.ObjectMapping;

public class DynamicFilterAutoMapperProfile : Profile
{
    public DynamicFilterAutoMapperProfile()
    {
        CreateMap<Person, PersonDto>().ReverseMap();
    }
}
