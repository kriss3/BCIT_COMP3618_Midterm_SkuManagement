namespace OrpSkuViewer.SharedObjects
{
    public class OrpSku
    {
        public int OrpSkuId { get; set; }
        public string OrpSkuName { get; set; }
        public string OrpSkuDescription { get; set; }
        public string Comment { get; set; }
        public string Product { get; set; }
        public int Term { get; set; }
        public string InUse { get; set; }
        public decimal? MfnFloorPrice { get; set; }
        public decimal? MsrpPrice { get; set; }
        public decimal? SkuPrice { get; set; }
    }
}
