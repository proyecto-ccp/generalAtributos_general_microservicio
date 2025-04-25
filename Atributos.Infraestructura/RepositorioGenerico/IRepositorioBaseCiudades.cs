using Atributos.Dominio.Entidades;

namespace Atributos.Infraestructura.RepositorioGenerico
{
    public interface IRepositorioBaseCiudades<T> : IDisposable where T : EntidadBase
    {
        Task<T> Crear(T entity);
        Task<T> BuscarPorLlave(object ValueKey);
        Task<List<T>> BuscarPorAtributo(int ValueAttribute, string Attribute);
        Task<List<T>> BuscarPorAtributo(Guid ValueAttribute, string Attribute);
        Task<List<T>> DarListado();
    }
}
