using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmovBanPt
    {
        public int INumIdPt { get; set; }
        public int INumDetPt { get; set; }
        public int INumDesBanPt { get; set; }
        public string CTipBandeja { get; set; }
        public string CEstBandeja { get; set; }
        public int ICodTraResponsable { get; set; }
        public string vContenido { get; set; }
        public DateTime? SdFecIngreso { get; set; }
        public DateTime? SdFecFinalizacion { get; set; }
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
