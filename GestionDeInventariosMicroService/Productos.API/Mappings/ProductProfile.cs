using AutoMapper;
using Productos.API.Dto;
using Productos.API.Entity;
using Shared.Models.Dto;

namespace Productos.API.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();


            CreateMap<ProductCreateDto, ProductDto>()
                .ForMember(dest => dest.ImageFileId, opt => opt.Ignore());

            CreateMap<ProductUpdateDto, ProductDto>()
                .ForMember(dest => dest.ImageFileId, opt => opt.Ignore());

            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.StoredFiles != null ? src.StoredFiles.Url : null));

        }
    }
}
