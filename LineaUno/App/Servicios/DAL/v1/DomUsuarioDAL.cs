using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;
using System;
using System.DirectoryServices.AccountManagement;

namespace LineaUno.App.Servicios.DAL.SMC.v1
{
    public class DomUsuarioDAL
    {
        public DomUsuarioAutenticacionResponse Login(DomUsuarioAutenticacionRequest credenciales, string dominio)
        {
            DomUsuarioAutenticacionResponse respuesta = null;
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dominio, credenciales.Usuario, credenciales.Contrasena);

                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, credenciales.Usuario);
                
                respuesta = new DomUsuarioAutenticacionResponse()
                {
                    NombreCompleto = user.DisplayName
                };
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return respuesta;
        }
    }
}
