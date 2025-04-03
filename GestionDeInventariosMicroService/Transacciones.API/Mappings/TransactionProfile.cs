using AutoMapper;
using Transacciones.API.Dto;
using Transacciones.API.Entity;

namespace Transacciones.API.Mappings
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
           
            CreateMap<TransactionCreateDTO, Transaction>();

            CreateMap<Transaction, TransactionResponseDto>()
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.TipoTransaccion, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Detalle, opt => opt.MapFrom(src => src.Detail))
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.PrecioTotal, opt => opt.MapFrom(src => src.Total));

            CreateMap<TransactionCreateDTO, Transaction>()
            .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detalle))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TipoTransaccion))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductoId));

        }

    }
}
