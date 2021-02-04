using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class PedidoTrabajoController : ControllerBase
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public PedidoTrabajoController(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }


        [HttpPost(ApiRoutes.PedidoTrabajo.ObtenerPT)]
        public async Task<IActionResult> Listar()
        {
            var response = await new PedidoTrabajoBLL(context, mapper).Listar();
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.PedidoTrabajo.ObtenerPT_Gantt)]
        public async Task<IActionResult> Listar_PT_Gantt([FromBody]GanttParRequest req)
        {
            var response = await new PedidoTrabajoBLL(context, mapper).Listar_PT_Gantt(req.PT, req.Descripcion, req.FeIni, req.FeFin);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.PedidoTrabajo.ObtenerPTBandeja)]
        public async Task<IActionResult> Listar_x_Bandeja()
        {
            var response = await new PedidoTrabajoBLL(context, mapper).Listar_x_Bandeja();
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.PedidoTrabajo.IniciarPedidoTrabajo)]
        public async Task<IActionResult> IniciarPedidoTrabajo([FromBody]MCMovEstadoPTRequest request)
        {
            var response = await new PedidoTrabajoBLL(context, mapper).Iniciar(request);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.PedidoTrabajo.RegistrarInconvenientePT)]
        public async Task<IActionResult> RegistrarInconvenientePT([FromBody]MCMovBanPTRequest request)
        {
            var response = await new PedidoTrabajoBLL(context, mapper).RegistrarIncidencia(request);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.PedidoTrabajo.FinalizarPedidoTrabajo)]
        public async Task<IActionResult> FinalizarPedidoTrabajo([FromBody]MCMovEstadoPTRequest request)
        {
            var response = await new PedidoTrabajoBLL(context, mapper).Finalizar(request);
            return new OkObjectResult(response);
        }

    }
}