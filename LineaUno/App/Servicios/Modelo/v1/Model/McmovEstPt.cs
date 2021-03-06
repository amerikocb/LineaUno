﻿using System;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Model
{
    public partial class McmovEstPt
    {
        public int INumIdPt { get; set; }
        public int INumDetPt { get; set; }
        public int INumDetEstPt { get; set; }
        public DateTime? SdFecIniEstado { get; set; }
        public DateTime? SdFecFinEstado { get; set; }
        public decimal? NDurPt { get; set; }
        public string VObsPt { get; set; }
        public string CEstPt { get; set; }
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
