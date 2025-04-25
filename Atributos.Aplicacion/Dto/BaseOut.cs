using Atributos.Aplicacion.Enum;
using System.Net;

namespace Atributos.Aplicacion.Dto
{
    public class BaseOut
    {
        public Resultado Resultado { get; set; }
        public string Mensaje { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
