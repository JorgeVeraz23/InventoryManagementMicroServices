using AutoMapper;
using Productos.API.Dto;
using Productos.API.Entity;

namespace Productos.API.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.StoredFiles != null ? src.StoredFiles.Url : null));

        }
    }
}
