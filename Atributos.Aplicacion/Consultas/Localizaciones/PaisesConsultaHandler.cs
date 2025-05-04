

using Atributos.Aplicacion.Dto.Pais;
using Atributos.Aplicacion.Enum;
using Atributos.Dominio.Servicios.Localizaciones;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atributos.Aplicacion.Consultas.Localizaciones
{
    public class PaisesConsultaHandler : IRequestHandler<PaisesConsulta, PaisOutList>
    {
        private readonly LocalizarPais _servicioPais;
        private readonly IMapper _mapper;

        public PaisesConsultaHandler(LocalizarPais servicio, IMapper mapper)
        {
            _servicioPais = servicio;
            _mapper = mapper;
        }
        public async Task<PaisOutList> Handle(PaisesConsulta request, CancellationToken cancellationToken)
        {
            PaisOutList output = new()
            {
                Paises = []
            };
            
            try
            {
                var paises = await _servicioPais.ObtenerPaises();

                if (paises.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No se encontraron paises";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    paises.ForEach(ciudad => output.Paises.Add(_mapper.Map<PaisDto>(ciudad)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "paises encontrados";
                    output.Status = HttpStatusCode.OK;

                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
