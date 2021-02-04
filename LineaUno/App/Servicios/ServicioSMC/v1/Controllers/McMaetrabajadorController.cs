using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class McMaetrabajadorController : ControllerBase
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McMaetrabajadorController(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }


        [HttpPost(ApiRoutes.Trabajador.ListarTrabajadorRecurso)]
        public async Task<IActionResult> ListarTrabajadores_Rec()
        {
            var response = await new McMaeTrabajadorBLL(context, mapper).ListarTrabajadores_Rec();
            return new OkObjectResult(response);
        }

    }
}