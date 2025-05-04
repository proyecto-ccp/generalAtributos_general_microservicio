
using Atributos.Aplicacion.Dto.Pais;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class PaisMapeador : Profile
    {
        public PaisMapeador()
        {
            CreateMap<Pais, PaisDto>().ReverseMap();
        }
    }
}
