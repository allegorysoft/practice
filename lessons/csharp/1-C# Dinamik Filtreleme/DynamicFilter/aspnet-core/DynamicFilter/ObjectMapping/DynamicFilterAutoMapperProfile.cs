using AutoMapper;
using DynamicFilter.Entities;
using DynamicFilter.Services.Dtos;

namespace DynamicFilter.ObjectMapping;

public class DynamicFilterAutoMapperProfile : Profile
{
    public DynamicFilterAutoMapperProfile()
    {
        CreateMap<Person, PersonDto>();
    }
}
