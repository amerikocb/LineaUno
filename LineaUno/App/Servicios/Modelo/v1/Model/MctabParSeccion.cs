using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class MctabParSeccion
    {
        public MctabParSeccion()
        {
            MctabParValor = new HashSet<MctabParValor>();
        }

        public int ICodParametro { get; set; }
        public int ICodParSeccion { get; set; }
        public string VNomParSeccion { get; set; }
        public string CCodTipDato { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

        public virtual MctabParametro ICodParametroNavigation { get; set; }
        public virtual ICollection<MctabParValor> MctabParValor { get; set; }
    }
}
