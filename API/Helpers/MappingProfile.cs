using API.DTOs;
using AutoMapper;
using Core.Entites;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(p => p.ProductBrand,  o => o.MapFrom(p => p.ProductBrand.Name))
            .ForMember(p=> p.ProductType, o => o.MapFrom(p => p.ProductType.Name))
            .ForMember(p => p.PictureUrl, o => o.MapFrom<PictureUrlResolver>());
        }
    }
}