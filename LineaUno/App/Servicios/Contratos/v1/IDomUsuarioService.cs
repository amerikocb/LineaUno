using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;

namespace LineaUno.App.Servicios.Contratos.SMC.v1
{
    public interface IDomUsuarioService
    {
        IActionResult Login([FromBody] DomUsuarioAutenticacionRequest request);
    }
}
