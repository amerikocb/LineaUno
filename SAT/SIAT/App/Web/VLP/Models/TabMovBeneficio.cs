using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabMovBeneficio
    {
        public int ICodContribuyente { get; set; }
        public DateTime SdFecUtilizado { get; set; }
        public short SiCodBeneficio { get; set; }
        public bool BEstActivo { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual TabContribuyente ICodContribuyenteNavigation { get; set; }
        public virtual TabBeneficio SiCodBeneficioNavigation { get; set; }
    }
}
