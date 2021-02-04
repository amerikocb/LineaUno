using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLP.Contracts.v1.Request;
using VLP.Models;

namespace VLP.Services.Interfaces
{
    public interface ITabContribuyenteService
    {
        /// <summary>INTERFACE-WEB SERVICE CONTRIBUYENTE</summary>
        /// <remarks>
        /// <list type = "bullet">
        /// <item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
        /// <item><FecCrea>09/01/2020</FecCrea></item></list>        
        /// </remarks>
        ///

        Task<TabContribuyente> TabContribuyenteBuscarActivoVigente(TabContribuyenteValidoRequest request);
    }
}
