using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmaeCargaForDos
    {
        public McmaeCargaForDos()
        {
            McdetCargaForDos = new HashSet<McdetCargaForDos>();
        }

        public int INumCarga { get; set; }
        public string CEstado { get; set; }
        public string CTipCarga { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

       public virtual ICollection<McdetCargaForDos> McdetCargaForDos { get; set; }

        public virtual ICollection<McmaeCargaTraForDos> McmaeCargaTraForDos { get; set; }
    }
}
