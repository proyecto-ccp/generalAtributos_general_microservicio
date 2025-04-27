using Atributos.Aplicacion.Dto.Zonas;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class ZonaMapeador : Profile
    {
        public ZonaMapeador() 
        {
            CreateMap<LocalizacionZona, ZonaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Idzona))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Zona))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Ciudad))
                .ReverseMap();
        }
    }
}
