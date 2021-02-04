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
    public class TabUsuarioController : ControllerBase
    {
        private readonly ITabUsuarioService _tabUsuarioService;

        public TabUsuarioController(ITabUsuarioService tabUsuarioService)
        {
            _tabUsuarioService = tabUsuarioService;
        }

        [HttpPost(ApiRoutes.TabUsuario.Login)]
        public IActionResult Login([FromBody] TabUsuarioAutenticacionRequest request)
        {
            var response = _tabUsuarioService.Login(request.IdUsuario, request.Contrasena);
            if (response == null) {
                return new UnauthorizedObjectResult(new
                {
                    Message = "Autenticación fallida.",
                    StatusCode = 401,
                    Error = "La combinación de usuario y contraseña es incorrecta."
                });
            }
            return new OkObjectResult(response);
        }
    }
}