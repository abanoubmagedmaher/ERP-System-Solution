using AutoMapper;
using Core.Entities;
using ERP_System.DTOS;

namespace ERP_System.Helpers
{
    public class MappingProfilies :Profile
    {
        public MappingProfilies()
        {

            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(d=> d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.ProductType,o =>o.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductURLResolver>());                               
        }
    }
}
