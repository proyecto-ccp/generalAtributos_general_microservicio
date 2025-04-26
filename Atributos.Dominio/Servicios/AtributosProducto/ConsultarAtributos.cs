
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.AtributosProducto
{
    public class ConsultarAtributos(IAtributosProductoRepositorio atributoRepositorio)
    {
        private readonly IAtributosProductoRepositorio _atributoRepositorio = atributoRepositorio;

        public async Task<List<Categoria>> DarCategorias()
        {
            return await _atributoRepositorio.DarCategorias() ?? [];
        }
        public async Task<List<Color>> DarColores()
        {
            return await _atributoRepositorio.DarColores() ?? [];
        }
        public async Task<List<Marca>> DarMarcas()
        {
            return await _atributoRepositorio.DarMarcas() ?? [];
        }
        public async Task<List<Material>> DarMateriales()
        {
            return await _atributoRepositorio.DarMateriales() ?? [];
        }
        public async Task<List<Medida>> DarMedidas()
        {
            return await _atributoRepositorio.DarMedidas() ?? [];
        }
        public async Task<List<Modelo>> DarModelos()
        {
            return await _atributoRepositorio.DarModelos() ?? [];
        }
    }
}
