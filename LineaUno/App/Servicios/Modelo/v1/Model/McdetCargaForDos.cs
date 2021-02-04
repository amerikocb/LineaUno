using System;
using System.Collections.Generic;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McdetCargaForDos
    {
        public int INumCarga { get; set; }
        public int INumDetCarga { get; set; }
        public string VNumPt { get; set; }
        public string VParFecha { get; set; }
        public string VHorInicio { get; set; }
        public string VHorFin { get; set; }
        public string VAreResponsable { get; set; }
        public string VRuc { get; set; }
        public string VRazSocial { get; set; }
        public string VZona { get; set; }
        public string VSecLinea { get; set; }
        public string VZonEspecifica { get; set; }
        public string VDesActividad { get; set; }
        public string VTipActividad { get; set; }
        public string VPrioridad { get; set; }
        public string VPerIntervencion { get; set; }
        public string VRecMedios { get; set; }
        public string VSupResConcar { get; set; }
        public string VCelSupResponsable { get; set; }
        public string VTeresConcar { get; set; }
        public string VCelTeresponsable { get; set; }
        public string VResTercero { get; set; }
        public string VCelTercero { get; set; }
        public string vTecnicoUno { get; set; }
        public string vTecnicoDos { get; set; }
        public string vTecnicoTres { get; set; }
        public string vTecnicoCuatro { get; set; }
        public string vTecnicoCinco { get; set; }
        public string VCodUsuCreacion { get; set; }
        public DateTime? SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public string VCodUsuModificacion { get; set; }
        public DateTime? SdFecModificacion { get; set; }
        public string CNomTerModificacion { get; set; }

        public virtual McmaeCargaForDos INumCargaNavigation { get; set; }
    }
}
