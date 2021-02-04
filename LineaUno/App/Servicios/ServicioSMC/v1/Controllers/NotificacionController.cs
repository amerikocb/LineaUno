using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class NotificacionController : ControllerBase
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public NotificacionController(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpPost(ApiRoutes.Notificacion.ObtenerNotBandeja)]
        public async Task<IActionResult> ListarNotificaciones_Bandeja()
        {
            var response = await new NotificacionBLL(context, mapper).ListarNotificaciones_Bandeja();
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.Notificacion.ResponderInconveniente)]
        public async Task<IActionResult> ResponderInconvenientePT([FromBody]MCMovBanPTRequest request)
        {
            var response = await new NotificacionBLL(context, mapper).ResponderInconvenientePT(request);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.Notificacion.ListarMotivosInconveniente)]
        public async Task<IActionResult> ListarMotivosInconv_x_PT(int PT, int detPT)
        {
            var response = await new NotificacionBLL(context, mapper).ListarMotivosInconv_x_PT(PT, detPT);
            return new OkObjectResult(response);
        }

    }
}