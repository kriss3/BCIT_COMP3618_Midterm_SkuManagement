using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrpSkuViewer.SharedObjects
{
    public class OrpSku
    {
        public int OrpSkuId { get; set; }
        public string OrpSkuName { get; set; }
        public string OrpSkuDescription { get; set; }
        public string Product { get; set; }
        public int Term { get; set; }
        public bool InUse { get; set; }
        public double MfnFloorPrice { get; set; }
        public double MsrpPrice { get; set; }
        public double  SkuPrice { get; set; }
    }
}
