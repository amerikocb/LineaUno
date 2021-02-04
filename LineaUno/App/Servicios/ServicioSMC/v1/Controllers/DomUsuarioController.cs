using LineaUno.App.Servicios.BLL.SMC.v1;
using LineaUno.App.Servicios.Contratos.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ServicioSMC.v1.Controllers
{
    public class DomUsuarioController : ControllerBase, IDomUsuarioService
    {
        private readonly IConfiguration config;
        public DomUsuarioController(IConfiguration _config)
        {
            this.config = _config;
        }

        [HttpPost(ApiRoutes.DomUsuario.Login)]
        public IActionResult Login([FromBody] DomUsuarioAutenticacionRequest request)
        {
            var domUsuarioBLL = new DomUsuarioBLL();

            string dominio = config.GetSection("AppSettings").GetSection("Dominio").Value;

            var response = domUsuarioBLL.Login(request, dominio);
            if (response == null)
            {
                return new UnauthorizedObjectResult(new
                {
                    Error = "Autenticación fallida.",
                    StatusCode = 401,
                    Mensaje = "La combinación de usuario y contraseña es incorrecta."
                });
            }
            return new OkObjectResult(response);
        }
    }
}