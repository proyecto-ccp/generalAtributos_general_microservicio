
using Atributos.Dominio.Entidades;

namespace Atributos.Dominio.Puertos.Repositorios
{
    public interface ITipoDocumentoRepositorio
    {
        Task<List<TipoDocumento>> DarListado();
    }
}
