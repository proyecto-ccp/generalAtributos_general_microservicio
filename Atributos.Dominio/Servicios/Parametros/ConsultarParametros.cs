

using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;

namespace Atributos.Dominio.Servicios.Parametros
{
    public class ConsultarParametros(IParametroRepositorio parametroRepositorio)
    {
        private readonly IParametroRepositorio _parametroRepositorio = parametroRepositorio;

        public async Task<List<Parametro>> DarParametros()
        {
            return await _parametroRepositorio.DarParametros();
        }

        public async Task<Parametro> DarParametro(string nombre)
        {
            return await _parametroRepositorio.DarParametro(nombre);
        }
    }
}
