using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class McSendMailRequest
    {
        public string Asunto { get; set; }
        public string Texto_Notificar { get; set; }
        public string Cuenta_Notificar { get; set; }
        public string Cuentas_Copias { get; set; }
        public string Profile_Correo { get; set; }
    }
}
