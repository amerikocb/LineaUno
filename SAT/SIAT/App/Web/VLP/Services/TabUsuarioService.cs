using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using VLP.Contracts.v1.Response;
using VLP.Services.Interfaces;

namespace VLP.Services
{
    public class TabUsuarioService: ITabUsuarioService
    {
        public TabUsuarioAutenticacionResponse Login(string idUsuario, string contrasena)
        {
            TabUsuarioAutenticacionResponse respuesta;
            //string dominio = ConfigurationManager.AppSettings["Dominio"];
            string dominio = "STRACON.COM";
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dominio, idUsuario, contrasena);

                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, idUsuario);
                
                respuesta = new TabUsuarioAutenticacionResponse()
                {
                    Nombre = user.DisplayName
                };
            }
            catch
            {
                respuesta = null;
            }
            return respuesta;
        }
    }
}
