using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class McmaeCargaForDosController : ControllerBase, IMcmaeCargaForDosService
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McmaeCargaForDosController(BDLINEAUNOContext _context, IMapper _mapper) {
            context = _context;
            mapper = _mapper;
        }

        [HttpPost(ApiRoutes.McmaeCargaForDos.CargaExcel)]
        public async Task<IActionResult> CargaExcel([FromForm] McmaeCargaForDosRequest request)
        {
            var McmaeCargaForDosBLL = new McmaeCargaForDosBLL(context, mapper);
            var response = await McmaeCargaForDosBLL.CargaExcel(request);
            if (response.Exito)
            {
                return new OkObjectResult(response);
            }
            else {
                return new BadRequestObjectResult(response);
            }
        }

        [HttpGet(ApiRoutes.McmaeCargaForDos.BusquedaCabecera)]
        public async Task<IActionResult> BusquedaCabecera([FromRoute] McmaeCargaForDosListadoRequest request)
        {
            var McmaeCargaForDosBLL = new McmaeCargaForDosBLL(context, mapper);
            var response = await McmaeCargaForDosBLL.BusquedaCabecera(request);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.McmaeCargaForDos.ProcesarPlantilla)]
        public async Task<IActionResult> ProcesarPlantilla([FromBody] McParametrosProcessPlantillaRequest request)
        {
            var McmaeCargaForDosBLL = new McmaeCargaForDosBLL(context, mapper);
            var response = await McmaeCargaForDosBLL.ProcesarPlantilla(request.NumCarga, request.Usuario, request.Computador);
            return new OkObjectResult(response);
        }
    }
}