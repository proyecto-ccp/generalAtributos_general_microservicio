using Atributos.Aplicacion.Dto.Zonas;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class ZonaMapeador : Profile
    {
        public ZonaMapeador() 
        {
            CreateMap<Zona, ZonaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Ciudad))
                .ReverseMap();

            CreateMap<Zona, ZonaIn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Ciudad))
                .ForMember(dest => dest.Limites, opt => opt.MapFrom(src => src.Limites))
                .ReverseMap();

            CreateMap<ZonaOut, ZonaIn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Zona.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Zona.Nombre))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Zona.Ciudad))
                .ForMember(dest => dest.Limites, opt => opt.MapFrom(src => src.Zona.Limites))
                .ReverseMap();
        }
    }
}
