using System.Collections.Generic;
using System.Threading.Tasks;
using VLP.Contracts.v1.Response;

namespace VLP.Services.Interfaces
{
    public interface ITabInstitucionService
    {
        /// <summary>INTERFACE-WEB SERVICE INSTITUCIÓN</summary>
        /// <remarks>
        /// <list type = "bullet">
        /// <item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
        /// <item><FecCrea>09/01/2020</FecCrea></item></list>        
        /// </remarks>
        ///

        Task<List<TabInstitucionResponse>> TabInstitucionListarPorEstadoEnOrdenPrioridadAsc(bool estado);
    }
}
