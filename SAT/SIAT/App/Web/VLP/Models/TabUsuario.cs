using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabUsuario
    {
        public short SiCodUsuario { get; set; }
        public string VIdUsuario { get; set; }
        public byte[] ContrasenaHash { get; set; }
        public byte[] ContrasenaSalt { get; set; }
        public bool BEstActivo { get; set; }
        public byte TiTipDocUsuario { get; set; }
        public string CNumDocContribuyente { get; set; }
        public short SiCodInstitucion { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual TabInstitucion SiCodInstitucionNavigation { get; set; }
    }
}
