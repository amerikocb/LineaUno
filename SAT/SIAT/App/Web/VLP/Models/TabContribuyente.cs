using System;
using System.Collections.Generic;

namespace VLP.Models
{
    public partial class TabContribuyente
    {
        public TabContribuyente()
        {
            TabMovBeneficio = new HashSet<TabMovBeneficio>();
        }

        public int ICodContribuyente { get; set; }
        public byte TiTipDocContribuyente { get; set; }
        public string CNumDocContribuyente { get; set; }
        public string VNomContribuyente { get; set; }
        public string VApeMatContribuyente { get; set; }
        public string VApePatContribuyente { get; set; }
        public DateTime SdFecCarContribuyente { get; set; }
        public DateTime SdFecIniVigencia { get; set; }
        public DateTime SdFecFinVigencia { get; set; }
        public bool BActivo { get; set; }
        public short SiCodUsuCreacion { get; set; }
        public DateTime SdFecCreacion { get; set; }
        public string CNomTerCreacion { get; set; }
        public short? SiCodUsu { get; set; }
        public DateTime? SdFecAct { get; set; }
        public string CNomTer { get; set; }

        public virtual ICollection<TabMovBeneficio> TabMovBeneficio { get; set; }
    }
}
