
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
    public class MedidaConsultaHandlerTest
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;
        private readonly Mock<IAtributosProductoRepositorio> mockAtributoRepositorio;

        public MedidaConsultaHandlerTest()
        {
            mockAtributoRepositorio = new Mock<IAtributosProductoRepositorio>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AtributoProductoMapeador()));
            _mapper = config.CreateMapper();
            _servicioAtributos = new ConsultarAtributos(mockAtributoRepositorio.Object);
        }

        /// <summary>
        /// Valida las posibles respuestas de la consulta de medidas
        /// </summary>
        [Theory]
        [InlineData(1, Resultado.Exitoso, HttpStatusCode.OK, "Consulta exitosa", 2)]
        [InlineData(2, Resultado.SinRegistros, HttpStatusCode.NotFound, "El atributo medidas no tiene valores", 0)]
        [InlineData(3, Resultado.Error, HttpStatusCode.InternalServerError, "Error", 0)]
        public async Task Handle_Medidas_Respuestas(int tipo, Resultado res, HttpStatusCode status, string msj, int cantidad)
        {
            List<Medida> medidas = [];
            if (tipo == 1)
            {
                medidas =
                [
                    new() { Id = 1, Nombre = "Color 1", Codigo = "CO1" },
                    new() { Id = 2, Nombre = "Color 2", Codigo = "CO2" },
                ];
            }
            if (tipo == 3)
            {
                mockAtributoRepositorio.Setup(repo => repo.DarMedidas()).ThrowsAsync(new Exception("Error"));
            }
            else
            {
                mockAtributoRepositorio.Setup(repo => repo.DarMedidas()).ReturnsAsync(medidas);
            }
            var objPrueba = new MedidaConsultaHandler(_servicioAtributos, _mapper);
            var resultado = await objPrueba.Handle(new MedidaConsulta(), CancellationToken.None);
            Assert.Equal(res, resultado.Resultado);
            Assert.Equal(status, resultado.Status);
            Assert.Equal(msj, resultado.Mensaje);
            Assert.Equal(cantidad, resultado.Medidas.Count);
        }

    }
}
