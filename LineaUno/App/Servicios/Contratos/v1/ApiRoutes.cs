using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Contratos.SMC.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string BaseUrl = Root + "/" + Version;

        public static class DomUsuario
        {
            public const string Login = BaseUrl + "/login";
        }
        public static class McmaeCargaForDos
        {
            public const string CargaExcel = BaseUrl + "/carga";
            public const string BusquedaCabecera = BaseUrl + "/busqueda-actividades/activo/{Activo}";
            public const string ProcesarPlantilla = BaseUrl + "/carga/procesar-plantilla";
        }

        public static class McdetCargaForDos
        {
            public const string BusquedaDetalles = BaseUrl + "/carga-actividad/{CodigoCarga:int}/detalles";
            public const string BusquedaEdicionDetalle = BaseUrl + "/actividad/{NumCarga:int},{CodigoDetalle:int}";
            public const string EdicionDetalle = BaseUrl + "/actividad/edicion";
            public const string BusquedaTrabajadores = BaseUrl + "/busqueda-trabajadores/{numCarga:int}/{numDetCarga:int}";
        }

        public static class MCTabOT
        {
            public const string BusquedaListado = BaseUrl + "/busqueda-listado/activo/{Activo}";
        }

        public static class PedidoTrabajo
        {
            public const string ObtenerPT = BaseUrl + "/listar-pt";
            public const string ObtenerPT_Gantt = BaseUrl + "/listar-pt-gantt";
            public const string ObtenerPTBandeja = BaseUrl + "/listar-pt-b";
            public const string IniciarPedidoTrabajo = BaseUrl + "/actividad/iniciar";
            public const string RegistrarInconvenientePT = BaseUrl + "/actividad/registrar-inconveniente";
            public const string FinalizarPedidoTrabajo = BaseUrl + "/actividad/finalizar";
        }
        public static class Recurso
        {
            public const string ObtenerRec = BaseUrl + "/listar-recurso";
            public const string ObtenerRecPT_Gantt = BaseUrl + "/listar-rec-pt-gantt";
        }

        public static class ParametroValor
        {
            public const string ListadoMotivos_x_Categoria = BaseUrl + "/listar-motivos-x-categoria/{idCategoria:int}";
            public const string Listar_Cat_Inconveniente = BaseUrl + "/listar-cat-inconveniente";
            public const string ListarValores_x_ICodParametro = BaseUrl + "/listar-valores-codparametro/{iCodParametro:int}";
            public const string ListarTabla_Validar = BaseUrl + "/listar-tabla-validar";
        }

        public static class Notificacion
        {
            public const string ObtenerNotBandeja = BaseUrl + "/listar-not-b";
            public const string ResponderInconveniente = BaseUrl + "/actividad/responder-inconveniente";
            public const string ListarMotivosInconveniente = BaseUrl + "/listar-motivos-inc/{PT:int}/{detPT:int}";
        }

        public static class Trabajador
        {
            public const string ListarTrabajadorRecurso = BaseUrl + "/listar-trabajador-recurso";
        }
    }
}
