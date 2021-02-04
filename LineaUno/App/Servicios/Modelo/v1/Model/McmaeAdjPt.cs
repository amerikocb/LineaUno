using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmaeAdjPt
    {
        public int INumIdPt { get; set; }
        public int INumDetPt { get; set; }
        public int INumDetAdjT { get; set; }
        public int ITipAdjunto { get; set; }
        public string VRutaAdjunto { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

        public virtual McdetPt INum { get; set; }
    }
}
