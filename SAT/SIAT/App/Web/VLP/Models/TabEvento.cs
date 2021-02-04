using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabEvento
    {
        public TabEvento()
        {
            TabAgenda = new HashSet<TabAgenda>();
        }

        public short SiCodEvento { get; set; }
        public string VNomEvento { get; set; }
        public string VDetEvento { get; set; }
        public bool BEstActivo { get; set; }
        public string VImgEvento { get; set; }
        public string VUrlEvento { get; set; }
        public short SiCodInstitucion { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual TabInstitucion SiCodInstitucionNavigation { get; set; }
        public virtual ICollection<TabAgenda> TabAgenda { get; set; }
    }
}
