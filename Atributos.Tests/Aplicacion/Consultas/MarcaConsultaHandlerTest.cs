
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
    public class MarcaConsultaHandlerTest
    {
        private readonly ConsultarAtributos _servicioAtributos;
        private readonly IMapper _mapper;
        private readonly Mock<IAtributosProductoRepositorio> mockAtributoRepositorio;

        public MarcaConsultaHandlerTest() 
        {
            mockAtributoRepositorio = new Mock<IAtributosProductoRepositorio>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AtributoProductoMapeador()));
            _mapper = config.CreateMapper();
            _servicioAtributos = new ConsultarAtributos(mockAtributoRepositorio.Object);
        }
        /// <summary>
        /// Valida las posibles respuestas de la consulta de marcas
        /// </summary>
        [Theory]
        [InlineData(1, Resultado.Exitoso, HttpStatusCode.OK, "Consulta exitosa", 2)]
        [InlineData(2, Resultado.SinRegistros, HttpStatusCode.NotFound, "El atributo marcas no tiene valores", 0)]
        [InlineData(3, Resultado.Error, HttpStatusCode.InternalServerError, "Error", 0)]
        public async Task Handle_Marca_Respuestas(int tipo, Resultado res, HttpStatusCode status, string msj, int cantidad)
        {
            List<Marca> marcas = [];
            if (tipo == 1)
            {
                marcas =
                [
                    new() { Id = 1, Nombre = "Color 1", Codigo = "CO1" },
                    new() { Id = 2, Nombre = "Color 2", Codigo = "CO2" },
                ];
            }
            if (tipo == 3)
            {
                mockAtributoRepositorio.Setup(repo => repo.DarMarcas()).ThrowsAsync(new Exception("Error"));
            }
            else
            {
                mockAtributoRepositorio.Setup(repo => repo.DarMarcas()).ReturnsAsync(marcas);
            }
            var objPrueba = new MarcaConsultaHandler(_servicioAtributos, _mapper);
            var resultado = await objPrueba.Handle(new MarcaConsulta(), CancellationToken.None);
            Assert.Equal(res, resultado.Resultado);
            Assert.Equal(status, resultado.Status);
            Assert.Equal(msj, resultado.Mensaje);
            Assert.Equal(cantidad, resultado.Marcas.Count);
        }
    }
}
