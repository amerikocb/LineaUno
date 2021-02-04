using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class MCMovEstadoPTRequest
    {
        public int iNumIdPT { get; set; }
        public int iNumDetPT { get; set; }
        public int iNumDetEstPT { get; set; }
        public string vCodUsuarioCreacion { get; set; }
        public string Terminal { get; set; }
        public string Opcion { get; set; }
    }
}
