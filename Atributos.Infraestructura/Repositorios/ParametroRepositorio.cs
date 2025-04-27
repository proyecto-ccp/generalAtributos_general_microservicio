

using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Infraestructura.RepositorioGenerico;

namespace Atributos.Infraestructura.Repositorios
{
    public class ParametroRepositorio : IParametroRepositorio
    {
        private readonly IRepositorioBase<Parametro> _parametro;

        public ParametroRepositorio(IRepositorioBase<Parametro> parametro) 
        {
            _parametro = parametro;
        }

        public async Task<Parametro> DarParametro(string nombre)
        {
            return await _parametro.BuscarPorLlave(nombre);
        }

        public async Task<List<Parametro>> DarParametros()
        {
            return await _parametro.DarListado();
        }
    }
}
