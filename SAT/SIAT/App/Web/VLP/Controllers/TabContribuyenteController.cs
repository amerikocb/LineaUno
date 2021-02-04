using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VLP.Contracts.v1;
using VLP.Contracts.v1.Request;
using VLP.Services.Interfaces;

namespace VLP.Controllers
{
    ///<summary>Clase Controller para gestionar la funcionalidad del contribuyente</summary>
    ///<remarks>
    ///<list type = "bullet">
    ///<item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
    ///<item><FecCrea>09/01/2020</FecCrea></item>
    ///</list></remarks>

    public class TabContribuyenteController : ControllerBase
    {
        private readonly ITabContribuyenteService _tabContribuyenteService;
        
        public TabContribuyenteController(ITabContribuyenteService tabContribuyenteService)
        {
            _tabContribuyenteService = tabContribuyenteService;
        }

        /// <summary>Método que busca al contribuyente activo y vigente, por tipo y numero de documento</summary>
        /// <param name="tipDocumento">Tipo de documento del contribuyente</param>
        /// <param name="numDocumento">Número de documento del contribuyente</param>
        /// <returns>ObjectResult</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
        /// <item><FecCrea>09/01/2020</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu></FecActu></item>
        /// <item><Resp></Resp></item>
        /// <item><Mot></Mot></item></list></remarks>

        [HttpGet(ApiRoutes.TabContribuyente.BuscarActivoVigente)]
        //public async Task<IActionResult> TabContribuyenteBuscarActivoVigente([FromRoute] byte tipDocumento, string numDocumento)
        public async Task<IActionResult> TabContribuyenteBuscarActivoVigente([FromRoute] TabContribuyenteValidoRequest request)
        {
            var response = await _tabContribuyenteService.TabContribuyenteBuscarActivoVigente(request);
            if (response != null)
                return new OkObjectResult(new { mensaje = "Felicitaciones usted es Vecino Limeño Puntual, disfrute sus beneficios!" });
            return new OkObjectResult(new { mensaje = "Lo lamentamos: Usted no cumple con los criterios mínimos para los beneficios Vecino Limeño Puntual." });
        }
    }
}