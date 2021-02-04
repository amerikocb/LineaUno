using System;
using System.Collections.Generic;
using System.Text;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Request
{
    public class GanttParRequest
    {
        public string PT { get; set; }
        public string Descripcion { get; set; }
        public string FeIni { get; set; }
        public string FeFin { get; set; }
    }
}
