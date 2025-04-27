
using Atributos.Aplicacion.Consultas.TiposDocumento;
using Atributos.Aplicacion.Dto.TiposDocumento;
using Atributos.Aplicacion.Enum;
using Atributos.Aplicacion.Mapeadores;
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Dominio.Servicios.TiposDocumento;
using Atributos.Tests.DataTests;
using AutoMapper;
using Moq;
using System.Net;

namespace Productos.Tests.Aplicacion.Consultas
{
    public class TiposDocumentoHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly ListadoTiposDocumento _listarDocumentos;
        private readonly Mock<ITipoDocumentoRepositorio> mockDocumentoRepositorio;

        public TiposDocumentoHandlerTest() 
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new TipoDocumentoMapeador()));
            _mapper = config.CreateMapper();
            mockDocumentoRepositorio = new Mock<ITipoDocumentoRepositorio>();
            _listarDocumentos = new ListadoTiposDocumento(mockDocumentoRepositorio.Object);
        
        }


        [Theory]
        [ClassData(typeof(TiposDocumentoHandlerDataTest))]
        public async Task TiposDocumentoHandler_Respuestas(List<TipoDocumento> documentos, TipoDocumentoOutList respuesta)
        {
            mockDocumentoRepositorio.Setup(m => m.DarListado()).ReturnsAsync(documentos);
            
            var objPrueba = new TiposDocumentoHandler(_listarDocumentos, _mapper);

            var resultado = await objPrueba.Handle(new TiposDocumentoConsulta(), CancellationToken.None);

            var verResultado = Assert.IsType<TipoDocumentoOutList>(resultado);
            Assert.Equal(respuesta.Resultado, verResultado.Resultado);
            Assert.Contains(respuesta.Mensaje, verResultado.Mensaje);
            Assert.Equal(respuesta.Status, verResultado.Status);
            Assert.Equal(respuesta.TiposDocumentos.Count, verResultado.TiposDocumentos.Count);

        }

        [Fact]
        public async Task TiposDocumentoHandler_Excepcion()
        {
            mockDocumentoRepositorio.Setup(m => m.DarListado()).ThrowsAsync(new Exception("Error en la consulta"));
            var objPrueba = new TiposDocumentoHandler(_listarDocumentos, _mapper);
            var resultado = await objPrueba.Handle(new TiposDocumentoConsulta(), CancellationToken.None);
            var verResultado = Assert.IsType<TipoDocumentoOutList>(resultado);
            Assert.Equal(Resultado.Error, verResultado.Resultado);
            Assert.Contains("Error en la consulta", verResultado.Mensaje);
            Assert.Equal(HttpStatusCode.InternalServerError, verResultado.Status);
        }


    }
}
