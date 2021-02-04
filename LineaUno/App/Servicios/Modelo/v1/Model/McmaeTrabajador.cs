using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmaeTrabajador
    {
        public int ICodTrabajador { get; set; }
        public string CTipTrabajador { get; set; }
        public string VCodigo { get; set; }
        public string VNomTrabajador { get; set; }
        public string VCorTrabajador { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }
    }
}
