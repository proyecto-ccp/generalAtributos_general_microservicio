using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.Zonas
{
    [ExcludeFromCodeCoverage]
    public class ZonaDto
    {
        public Guid Id { get; set; }
        public Guid IdCiudad { get; set; }
        public string? Ciudad { get; set; }
        public string Nombre { get; set; }
        public string Limites { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ZonaOut : BaseOut
    {
        public ZonaDto Zona { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ZonaOutList : BaseOut
    {
        public List<ZonaDto> Zonas { get; set; }
    }
}
