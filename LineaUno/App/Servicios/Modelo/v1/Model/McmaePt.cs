using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmaePt
    {
        public McmaePt()
        {
            McdetPt = new HashSet<McdetPt>();
        }

        public int INumIdPt { get; set; }
        public string VNumPt { get; set; }
        public string CEstPt { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

        public virtual ICollection<McdetPt> McdetPt { get; set; }
    }
}
