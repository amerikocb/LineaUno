using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VLP.Contracts.v1.Response;

namespace VLP.Services.Interfaces
{
    public interface ITabUsuarioService
    {
        TabUsuarioAutenticacionResponse Login(string idUsuario, string contrasena);
    }
}
