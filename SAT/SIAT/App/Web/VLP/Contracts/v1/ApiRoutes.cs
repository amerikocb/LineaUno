using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VLP.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string BaseUrl = Root + "/" + Version;

        public static class TabContribuyente
        {
            public const string BuscarActivoVigente = BaseUrl + "/contribuyente/tipo_documento/{TipoDocumento}/numero/{NumeroDocumento}";
        }
        public static class TabInstitucion
        {
            public const string ListarActivosEnOrdenDePrioridad = BaseUrl + "/institucion/activos";
        }
        public static class TabCatBeneficio
        {
            public const string BuscarActivoPorPrioridad = BaseUrl + "/categoria/beneficio/activos";
        }
        public static class TabUsuario
        {
            public const string Login = BaseUrl + "/login";
        }
    }
}
