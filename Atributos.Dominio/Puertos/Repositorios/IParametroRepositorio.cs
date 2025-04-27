
using Atributos.Dominio.Entidades;

namespace Atributos.Dominio.Puertos.Repositorios
{
    public interface IParametroRepositorio
    {
        Task<Parametro> DarParametro(string nombre);
        Task<List<Parametro>> DarParametros();
    }
}
