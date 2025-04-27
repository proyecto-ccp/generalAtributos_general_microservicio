using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.Ciudades
{
    [ExcludeFromCodeCoverage]
    public class CiudadDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Poblacion { get; set; }
        
    }

    [ExcludeFromCodeCoverage]
    public class CiudadOut : BaseOut
    { 
        public CiudadDto Ciudad { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CiudadOutList: BaseOut
    {
        public List<CiudadDto> Ciudades { get; set; }
    }
}
