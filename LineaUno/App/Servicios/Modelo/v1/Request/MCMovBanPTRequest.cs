using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class MCMovBanPTRequest
    {
        public int iNumIdPT { get; set; }
        public int iNumDetPT { get; set; }
        public int iNumDesBandPT { get; set; }
        public string vCodUsuarioCreacion { get; set; }
        public string Terminal { get; set; }
        public int ICodTraResponsable { get; set; }
        public string VTipInconveniente { get; set; }
        public string VDescInconveniente { get; set; }
        public string Mensaje { get; set; }
        public string Email { get; set; }
        public string PedidoTrabajo { get; set; }
        public IEnumerable<string> Rutas { get; set; }
        public int IdCategoria { get; set; }
    }
}
