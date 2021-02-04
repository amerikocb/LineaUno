using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabBeneficio
    {
        public TabBeneficio()
        {
            TabDetBeneficio = new HashSet<TabDetBeneficio>();
            TabMovBeneficio = new HashSet<TabMovBeneficio>();
        }

        public short SiCodBeneficio { get; set; }
        public string VNomBeneficio { get; set; }
        public string VDetBeneficio { get; set; }
        public DateTime SdFecVigInicio { get; set; }
        public DateTime SdFecVigFin { get; set; }
        public bool BEstActivo { get; set; }
        public byte SiCodCatBeneficio { get; set; }
        public byte TiCodPeriodo { get; set; }
        public string VNomProAlmacenado { get; set; }
        public short SiNumUsoPermitido { get; set; }
        public byte TiNumPrioridad { get; set; }
        public string VImgBeneficio { get; set; }
        public short SiCodInstitucion { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual TabCatBeneficio SiCodCatBeneficioNavigation { get; set; }
        public virtual TabInstitucion SiCodInstitucionNavigation { get; set; }
        public virtual TabPeriodo TiCodPeriodoNavigation { get; set; }
        public virtual ICollection<TabDetBeneficio> TabDetBeneficio { get; set; }
        public virtual ICollection<TabMovBeneficio> TabMovBeneficio { get; set; }
    }
}
