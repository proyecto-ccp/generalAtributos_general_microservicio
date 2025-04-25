using Atributos.Aplicacion.Dto.TiposDocumento;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class TipoDocumentoMapeador: Profile
    {
        public TipoDocumentoMapeador()
        {
            CreateMap<TipoDocumento, TipoDocumentoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ReverseMap();

            CreateMap<TipoDocumento, TipoDocumentoIn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ReverseMap();

            CreateMap<TipoDocumentoOut, TipoDocumentoIn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TipoDocumento.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.TipoDocumento.Nombre))
                .ReverseMap();
        }
    }
}
