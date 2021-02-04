using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class MctabParametro
    {
        public MctabParametro()
        {
            MctabParSeccion = new HashSet<MctabParSeccion>();
        }

        public int ICodParametro { get; set; }
        public string VNomParametro { get; set; }
        public string VDesParametro { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

        public virtual ICollection<MctabParSeccion> MctabParSeccion { get; set; }
    }
}
