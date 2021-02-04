using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabPeriodo
    {
        public TabPeriodo()
        {
            TabBeneficio = new HashSet<TabBeneficio>();
        }

        public byte TiCodPeriodo { get; set; }
        public string VDesPeriodo { get; set; }
        public bool BEstActivo { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual ICollection<TabBeneficio> TabBeneficio { get; set; }
    }
}
