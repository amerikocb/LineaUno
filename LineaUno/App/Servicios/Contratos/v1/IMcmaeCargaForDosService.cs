using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LineaUno.App.Servicios.Contratos.SMC.v1
{
    public interface IMcmaeCargaForDosService
    {
        Task<IActionResult> CargaExcel([FromForm] McmaeCargaForDosRequest request);
    }
}
