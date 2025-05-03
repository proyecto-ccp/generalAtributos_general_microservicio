
using Atributos.Aplicacion.Dto.TiposDocumento;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Entidades;
using System.Net;


namespace Atributos.Tests.DataTests
{
    public class TiposDocumentoHandlerDataTest : TheoryData<List<TipoDocumento>, TipoDocumentoOutList>
    {
        public TiposDocumentoHandlerDataTest() 
        {
            List<TipoDocumento> documentosOk =
            [
                    new () { Id = 1, Codigo = "CC", Nombre = "pruebas 1" },
                    new () { Id = 2, Codigo = "CE", Nombre = "pruebas 2"},
                    new () { Id = 3, Codigo = "NIT", Nombre = "pruebas 3"}
            ];

            var respuestaOk = new TipoDocumentoOutList
            {
                Resultado = Resultado.Exitoso,
                Mensaje = "Consulta exitosa",
                Status = HttpStatusCode.OK,
                TiposDocumentos =
                [
                    new () { Id = 1, Codigo = "CC", Nombre = "pruebas 1" },
                    new () { Id = 2, Codigo = "CE", Nombre = "pruebas 2"},
                    new () { Id = 3, Codigo = "NIT", Nombre = "pruebas 3"}
                ]
            };

            var respuestaVacio = new TipoDocumentoOutList
            {
                Resultado = Resultado.SinRegistros,
                Mensaje = "Tipos de documento no tiene valores",
                Status = HttpStatusCode.NotFound,
                TiposDocumentos = []
            };

            Add(documentosOk, respuestaOk);
            Add([], respuestaVacio);
            Add(null, respuestaVacio);

        }

    }
}
