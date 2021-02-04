using LineaUno.App.Servicios.DAL.SMC.v1;
using LineaUno.App.Servicios.Modelo.SMC.v1.Request;
using LineaUno.App.Servicios.Modelo.SMC.v1.Response;

namespace LineaUno.App.Servicios.BLL.SMC.v1
{
    public class DomUsuarioBLL
    {
        public DomUsuarioAutenticacionResponse Login(DomUsuarioAutenticacionRequest credenciales, string dominio)
        {
            var domUsuarioDAL = new DomUsuarioDAL();
            return domUsuarioDAL.Login(credenciales, dominio);
        }
    }
}
