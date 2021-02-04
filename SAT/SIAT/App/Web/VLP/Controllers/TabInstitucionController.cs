using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VLP.Contracts.v1;
using VLP.Services.Interfaces;

namespace VLP.Controllers
{
    ///<summary>Clase Controller para gestionar la funcionalidad de la institución</summary>
    ///<remarks>
    ///<list type = "bullet">
    ///<item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
    ///<item><FecCrea>09/01/2020</FecCrea></item>
    ///</list></remarks>
    
    public class TabInstitucionController : ControllerBase
    {
        private readonly ITabInstitucionService _tabInstitucionService;

        public TabInstitucionController(ITabInstitucionService tabInstitucionService)
        {
            _tabInstitucionService = tabInstitucionService;
        }

        /// <summary>Método que lista las instituciones activas en orden de prioridad</summary>
        /// <param name=""></param>
        /// <returns>ObjectResult</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
        /// <item><FecCrea>09/01/2020</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu></FecActu></item>
        /// <item><Resp></Resp></item>
        /// <item><Mot></Mot></item></list></remarks>

        [HttpGet(ApiRoutes.TabInstitucion.ListarActivosEnOrdenDePrioridad)]
        public async Task<IActionResult> TabInstitucionListarActivosEnOrdenPrioridadAsc()
        {
            var response = await _tabInstitucionService.TabInstitucionListarPorEstadoEnOrdenPrioridadAsc(true);
            return new OkObjectResult(response);
        }
    }
}