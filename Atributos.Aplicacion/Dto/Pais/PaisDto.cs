
using Atributos.Aplicacion.Dto.Ciudades;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Aplicacion.Dto.Pais
{
    [ExcludeFromCodeCoverage]
    public class PaisDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdIdioma { get; set; }
        public string Idioma { get; set; }
        public int IdMoneda { get; set; }
        public string Moneda { get; set; }
        public string AcronimoMoneda { get; set; }
        public string Indicativo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PaisOut : BaseOut
    {
        public PaisDto Pais { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PaisOutList : BaseOut
    {
        public List<PaisDto> Paises { get; set; }
    }
}
