using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabAgenda
    {
        public short SiCodEvento { get; set; }
        public byte TiCodAgenda { get; set; }
        public DateTime SdFecIniEvento { get; set; }
        public DateTime SdFecFinEvento { get; set; }
        public bool BEstActivo { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual TabEvento SiCodEventoNavigation { get; set; }
    }
}
