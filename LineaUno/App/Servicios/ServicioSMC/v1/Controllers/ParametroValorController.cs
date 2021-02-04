using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class ParametroValorController : ControllerBase
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public ParametroValorController(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }


        [HttpPost(ApiRoutes.ParametroValor.ListadoMotivos_x_Categoria)]
        public async Task<IActionResult> ListadoMotivos_x_Categoria(int idCategoria)
        {
            var response = await new ParametroValorBLL(context, mapper).ListadoMotivos_x_Categoria(idCategoria);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.ParametroValor.Listar_Cat_Inconveniente)]
        public async Task<IActionResult> Listar_Cat_Inconveniente()
        {
            var response = await new ParametroValorBLL(context, mapper).Listar_Cat_Inconveniente();
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.ParametroValor.ListarValores_x_ICodParametro)]
        public async Task<IActionResult> ListarValores_x_ICodParametro(int iCodParametro)
        {
            var response = await new ParametroValorBLL(context, mapper).ListarValores_x_ICodParametro(iCodParametro);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.ParametroValor.ListarTabla_Validar)]
        public async Task<IActionResult> ListarTabla_Validar()
        {
            var response = await new ParametroValorBLL(context, mapper).ListarTabla_Validar();
            return new OkObjectResult(response);
        }

    }
}