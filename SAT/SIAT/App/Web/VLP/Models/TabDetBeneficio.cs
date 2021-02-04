using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabDetBeneficio
    {
        public short SiCodBeneficio { get; set; }
        public byte TiCodDetBeneficio { get; set; }
        public string VDesDetBeneficio { get; set; }
        public bool BEstActivo { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual TabBeneficio SiCodBeneficioNavigation { get; set; }
    }
}
