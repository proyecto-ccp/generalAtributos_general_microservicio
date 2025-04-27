using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class CiudadMapeador : Profile
    {
        public CiudadMapeador()
        {

            CreateMap<Localizacion, CiudadDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Idciudad))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Ciudad))
                .ReverseMap();
        }
    }
}
