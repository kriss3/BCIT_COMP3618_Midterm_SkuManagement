namespace OrpSkuViewer.SharedObjects
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Base POCO class representing in-memory Order Processing SKU;
    /// </summary>
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
