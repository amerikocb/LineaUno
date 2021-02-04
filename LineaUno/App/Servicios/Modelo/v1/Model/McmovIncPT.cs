using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmovIncPT
    {
        public int INumIdPt { get; set; }
        public int INumDetPt { get; set; }
        public int INumDetIncPt { get; set; }
        public int ICodCatInconveniente { get; set; }
        public int ICodMotInconveniente { get; set; }
        public string vDesMotInconveniente { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }
    }
}
