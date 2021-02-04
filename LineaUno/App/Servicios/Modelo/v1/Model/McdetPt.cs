using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McdetPt
    {
        public McdetPt()
        {
            McmaeAdjPt = new HashSet<McmaeAdjPt>();
            McmaeTraPt = new HashSet<McmaeTraPt>();
            McmovEstPt = new HashSet<McmovEstPt>();
        }

        public int INumIdPt { get; set; }
        public int INumDetPt { get; set; }
        public DateTime? SdFecProgramada { get; set; }
        public string CHorInicio { get; set; }
        public string CHorFin { get; set; }
        public int? ICodAreResponsable { get; set; }
        public string CRuc { get; set; }
        public string CRazSocial { get; set; }
        public int? ICodZona { get; set; }
        public string VSecLinea { get; set; }
        public string VZonEspecifica { get; set; }
        public string VDesActividad { get; set; }
        public int? ICodTipActividad { get; set; }
        public int? ICodPrioridad { get; set; }
        public bool? BPerIntervencion { get; set; }
        public string VRecMedios { get; set; }
        public string VResTercero { get; set; }
        public string VCelResTercero { get; set; }
        public bool? BEstRegistro { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

        public virtual McmaePt INumIdPtNavigation { get; set; }
        public virtual ICollection<McmaeAdjPt> McmaeAdjPt { get; set; }
        public virtual ICollection<McmaeTraPt> McmaeTraPt { get; set; }
        public virtual ICollection<McmovEstPt> McmovEstPt { get; set; }
    }
}
