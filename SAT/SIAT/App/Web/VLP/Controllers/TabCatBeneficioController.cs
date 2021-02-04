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
    ///<summary>Clase Controller para gestionar la funcionalidad de la categoria del beneficio</summary>
    ///<remarks>
    ///<list type = "bullet">
    ///<item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
    ///<item><FecCrea>09/01/2020</FecCrea></item>
    ///</list></remarks>
    
    public class TabCatBeneficioController : ControllerBase
    {
        private readonly ITabCatBeneficioService _tabCatBeneficioService;

        public TabCatBeneficioController(ITabCatBeneficioService tabCatBeneficioService)
        {
            _tabCatBeneficioService = tabCatBeneficioService;
        }

        /// <summary>Método que lista los beneficios activos agrupados por categoria </summary>
        /// <param name=""></param>
        /// <returns>ObjectResult</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
        /// <item><FecCrea>09/01/2020</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu></FecActu></item>
        /// <item><Resp></Resp></item>
        /// <item><Mot></Mot></item></list></remarks>

        [HttpGet(ApiRoutes.TabCatBeneficio.BuscarActivoPorPrioridad)]
        public async Task<IActionResult> TabCatBeneficioBuscarActivoPorPrioridad()
        {
            var response = await _tabCatBeneficioService.TabCatBeneficioListarPorEstado(true);
            return new OkObjectResult(response);
        }
    }
}