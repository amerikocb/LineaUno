using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class RecursoController : ControllerBase
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public RecursoController(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }


        [HttpPost(ApiRoutes.Recurso.ObtenerRec)]
        public async Task<IActionResult> Listar()
        {
            var response = await new RecursoBLL(context, mapper).Listar();
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.Recurso.ObtenerRecPT_Gantt)]
        public async Task<IActionResult> Listar_Recursos_PT_Gantt([FromBody]GanttParRequest req)
        {
            var response = await new RecursoBLL(context, mapper).Listar_Recursos_PT_Gantt(req.PT, req.Descripcion, req.FeIni, req.FeFin);
            return new OkObjectResult(response);
        }
    }
}