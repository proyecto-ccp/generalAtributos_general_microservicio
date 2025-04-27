
using Atributos.Aplicacion.Dto.TiposDocumento;
using MediatR;
using System.Diagnostics.CodeAnalysis;


namespace Atributos.Aplicacion.Consultas.TiposDocumento
{
    [ExcludeFromCodeCoverage]
    public record TiposDocumentoConsulta() : IRequest<TipoDocumentoOutList>;
    
}
