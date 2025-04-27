
using Atributos.Aplicacion.Dto.AtributosProducto;
using Atributos.Dominio.Entidades;
using AutoMapper;

namespace Atributos.Aplicacion.Mapeadores
{
    public class AtributoProductoMapeador : Profile
    {
        public AtributoProductoMapeador() 
        {
            CreateMap<Modelo, ModeloDto>().ReverseMap();
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Medida, MedidaDto>().ReverseMap();
        }
    }
}
