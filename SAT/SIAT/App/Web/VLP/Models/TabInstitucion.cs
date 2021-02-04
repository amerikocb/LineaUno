using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabInstitucion
    {
        public TabInstitucion()
        {
            TabBeneficio = new HashSet<TabBeneficio>();
            TabEvento = new HashSet<TabEvento>();
            TabUsuario = new HashSet<TabUsuario>();
        }

        public short SiCodInstitucion { get; set; }
        public byte TiCodCatInstitucion { get; set; }
        public string VNomInstitucion { get; set; }
        public string VImgLogo { get; set; }
        public byte TiNumPrioridad { get; set; }
        public bool BEstActivo { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual ICollection<TabBeneficio> TabBeneficio { get; set; }
        public virtual ICollection<TabEvento> TabEvento { get; set; }
        public virtual ICollection<TabUsuario> TabUsuario { get; set; }
    }
}
