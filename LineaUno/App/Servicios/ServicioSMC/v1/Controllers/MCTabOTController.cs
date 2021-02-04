using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServicioSMC.v1.Controllers
{
    public class MCTabOTController : ControllerBase, IMCTabOTService
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public MCTabOTController(BDLINEAUNOContext _context, IMapper _mapper) {
            context = _context;
            mapper = _mapper;
        }


        //[HttpGet(ApiRoutes.MCTabOT.BusquedaListado)]
        //public async Task<IActionResult> BusquedaListado([FromRoute] MCTabOTListadoRequest request)
        //{
        //    var MCTabOTBLL = new MCTabOTBLL(context, mapper);
        //    var response = await MCTabOTBLL.BusquedaListadoOT(request);
        //    return new OkObjectResult(response);
        //}
    }
}