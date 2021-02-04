using System.Collections.Generic;
using System.Threading.Tasks;
using VLP.Models;

namespace VLP.Services.Interfaces
{
    public interface ITabBeneficioService
    {
        /// <summary>INTERFACE-WEB SERVICE BENEFICIO</summary>
        /// <remarks>
        /// <list type = "bullet">
        /// <item><CreadoPor>Luis Miguel Valeriano Vega</CreadoPor></item>
        /// <item><FecCrea>09/01/2020</FecCrea></item></list>        
        /// </remarks>
        ///

        Task<List<TabBeneficio>> TabBeneficioListarPorCategoriaYEstado(byte categoria, bool activos);
    }
}
