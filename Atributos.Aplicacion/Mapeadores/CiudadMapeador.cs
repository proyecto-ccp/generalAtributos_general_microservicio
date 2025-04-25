using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class CiudadMapeador : Profile
    {
        public CiudadMapeador()
        {
            CreateMap<Ciudad, CiudadDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Poblacion, opt => opt.MapFrom(src => src.Poblacion))
                .ReverseMap();

            CreateMap<Ciudad, CiudadIn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdRegion, opt => opt.MapFrom(src => src.IdRegion))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Poblacion, opt => opt.MapFrom(src => src.Poblacion))
                .ReverseMap();

            CreateMap<CiudadOut, CiudadIn>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ciudad.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Ciudad.Nombre))
                .ForMember(dest => dest.Poblacion, opt => opt.MapFrom(src => src.Ciudad.Poblacion))
                .ReverseMap();
        }
    }
}
