
using Atributos.Aplicacion.Consultas.AtributosProducto;
using Atributos.Aplicacion.Enum;
using Atributos.Aplicacion.Mapeadores;
using Atributos.Dominio.Entidades;
using Atributos.Dominio.Puertos.Repositorios;
using Atributos.Dominio.Servicios.AtributosProducto;
using AutoMapper;
using Moq;
using System.Net;

namespace Productos.Tests.Aplicacion.Consultas
{
    public class ModeloConsultaHandlerTest
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;
        private readonly Mock<IAtributosProductoRepositorio> mockAtributoRepositorio;

        public ModeloConsultaHandlerTest()
        {
            mockAtributoRepositorio = new Mock<IAtributosProductoRepositorio>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AtributoProductoMapeador()));
            _mapper = config.CreateMapper();
            _servicioAtributos = new ConsultarAtributos(mockAtributoRepositorio.Object);
        }

        /// <summary>
        /// Valida las posibles respuestas de la consulta de modelos
        /// </summary>
        [Theory]
        [InlineData(1, Resultado.Exitoso, HttpStatusCode.OK, "Consulta exitosa", 2)]
        [InlineData(2, Resultado.SinRegistros, HttpStatusCode.NotFound, "El atributo modelos no tiene valores", 0)]
        [InlineData(3, Resultado.Error, HttpStatusCode.InternalServerError, "Error", 0)]
        public async Task Handle_Modelos_Respuestas(int tipo, Resultado res, HttpStatusCode status, string msj, int cantidad)
        {
            List<Modelo> modelos = [];
            if (tipo == 1)
            {
                modelos =
                [
                    new() { Id = 1, Nombre = "Color 1", Codigo = "CO1" },
                    new() { Id = 2, Nombre = "Color 2", Codigo = "CO2" },
                ];
            }
            if (tipo == 3)
            {
                mockAtributoRepositorio.Setup(repo => repo.DarModelos()).ThrowsAsync(new Exception("Error"));
            }
            else
            {
                mockAtributoRepositorio.Setup(repo => repo.DarModelos()).ReturnsAsync(modelos);
            }
            var objPrueba = new ModeloConsultaHandler(_servicioAtributos, _mapper);
            var resultado = await objPrueba.Handle(new ModeloConsulta(), CancellationToken.None);
            Assert.Equal(res, resultado.Resultado);
            Assert.Equal(status, resultado.Status);
            Assert.Equal(msj, resultado.Mensaje);
            Assert.Equal(cantidad, resultado.Modelos.Count);
        }
    }
}
