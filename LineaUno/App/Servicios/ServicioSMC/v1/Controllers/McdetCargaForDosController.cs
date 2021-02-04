using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Model;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServicioSMC.v1.Controllers
{
    public class McdetCargaForDosController : ControllerBase
    {
        private readonly BDLINEAUNOContext context;
        private readonly IMapper mapper;

        public McdetCargaForDosController(BDLINEAUNOContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet(ApiRoutes.McdetCargaForDos.BusquedaDetalles)]
        public async Task<IActionResult> BusquedaDetalles([FromRoute] McdetCargaForDosListadoRequest request)
        {
            var McdetCargaForDosBLL = new McdetCargaForDosBLL(context, mapper);
            var response = await McdetCargaForDosBLL.BusquedaDetalle(request);
            return new OkObjectResult(response);
        }

        [HttpGet(ApiRoutes.McdetCargaForDos.BusquedaEdicionDetalle)]
        public async Task<IActionResult> BusquedaEdicionDetalle([FromRoute] McdetCargaForDosBusquedaEdicionRequest request)
        {
            var McdetCargaForDosBLL = new McdetCargaForDosBLL(context, mapper);
            var response = await McdetCargaForDosBLL.BusquedaEdicion(request);
            return new OkObjectResult(response);
        }

        [HttpPut(ApiRoutes.McdetCargaForDos.EdicionDetalle)]
        public async Task<IActionResult> EdicionDetalle([FromBody] McdetCargaForDosEdicionRequest request)
        {
            var McdetCargaForDosBLL = new McdetCargaForDosBLL(context, mapper);
            var response = await McdetCargaForDosBLL.Edicion(request);
            return new OkObjectResult(response);
        }

        [HttpPost(ApiRoutes.McdetCargaForDos.BusquedaTrabajadores)]
        public async Task<IActionResult> ListarTrabajadores_Carga(int numCarga, int numDetCarga)
        {
            var McdetCargaForDosBLL = new McdetCargaForDosBLL(context, mapper);
            var response = await McdetCargaForDosBLL.ListarTrabajadores_Carga(numCarga, numDetCarga);
            return new OkObjectResult(response);
        }
    }
}