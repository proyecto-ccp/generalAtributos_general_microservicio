
using Atributos.Aplicacion.Dto.Ciudades;
using Atributos.Aplicacion.Dto.Zonas;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    [ExcludeFromCodeCoverage]
    /// Consultas de Ciudades
    public record CiudadesConsulta : IRequest<CiudadOutList>;
    public record CiudadPorRegionConsulta(int IdRegion) : IRequest<CiudadOutList>;
    public record CiudadPorIdConsulta(Guid Id) : IRequest<CiudadOut>;
    
    /// Consultas de zonas
    public record ZonasConsulta : IRequest<ZonaOutList>;
    public record ZonasPorCiudadConsulta(Guid IdCiudad) : IRequest<ZonaOutList>;
    public record ZonaPorIdConsulta(Guid Id) : IRequest<ZonaOut>;

}
