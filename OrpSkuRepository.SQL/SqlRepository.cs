using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrpSkuRepository.Interface;
using OrpSkuViewer.SharedObjects;

namespace OrpSkuRepository.Sql
{
    public class SqlRepository : ISkuRepository
    {
        public void AddSku(OrpSku newOrpSku)
        {
            using (var ctx = new OrpSkuInventoryEntities())
            {
                if (GetSkuInventoryRecord(ctx, newOrpSku.OrpSkuName) != null)
                    return;

                var orpSku = new SkuInventoryDb()
                {
                    ID = newOrpSku.OrpSkuId,
                    Item_Description = newOrpSku.OrpSkuDescription,
                    Item_Number = newOrpSku.OrpSkuName,
                    InUse = newOrpSku.InUse.ToString(),
                    Term = newOrpSku.Term,
                    Product = newOrpSku.Product,
                    SkuPrice = (decimal?)newOrpSku.SkuPrice,
                    MsrpPrice = (decimal?)newOrpSku.MsrpPrice,
                };
                ctx.SkuInventoryDbs.Add(orpSku);
                ctx.SaveChanges();
            }
        }

        public void DeleteSku(string orpSkuName)
        {
            using (var ctx = new OrpSkuInventoryEntities())
            {
                var foundSku = GetSkuInventoryRecord(ctx, orpSkuName);
                if (foundSku == null)
                    return;

                ctx.SkuInventoryDbs.Remove(foundSku);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<OrpSku> GetAllSku()
        {
            using (var ctx = new OrpSkuInventoryEntities())
            {
                var orpSkus = (from s in ctx.SkuInventoryDbs
                              select new OrpSku
                              {
                                  OrpSkuId = s.ID,
                                  OrpSkuDescription = s.Item_Description,
                                  OrpSkuName = s.Item_Number,
                                  
                                  InUse = s.InUse,
                                  Term = s.Term.Value,
                                  Product = s.Product,
                                  SkuPrice = s.SkuPrice,
                                  MsrpPrice = s.MsrpPrice,
                                  MfnFloorPrice = s.MfnFloorPrice
                                  
                              }).ToList();

                return orpSkus;
            }
        }

        public OrpSku GetSkuById(int orpSkuId)
        {
            using (var ctx = new OrpSkuInventoryEntities())
            {
                var skuResult = (from s in ctx.SkuInventoryDbs
                                 where s.ID == orpSkuId
                                 select new OrpSku
                                 {
                                     OrpSkuId = s.ID,
                                     OrpSkuName = s.Item_Number,
                                     OrpSkuDescription = s.Item_Description,
                                     InUse = s.InUse,
                                     Term = s.Term.Value,
                                     Product = s.Product,
                                     SkuPrice = s.SkuPrice,
                                     MsrpPrice = s.MsrpPrice
                                 }).FirstOrDefault();
                return skuResult;
            }
        }

        public OrpSku GetSkuByName(string orpSkuName)
        {
            OrpSku orpSku = null;

            using (var ctx = new OrpSkuInventoryEntities())
            {
                var foundSku = GetSkuInventoryRecord(ctx, orpSkuName);
                if (foundSku != null)
                    orpSku = GetOrpSkuFromSkuInventory(foundSku);
            }
            return orpSku;
        }

        public void UpdateSku(string orpSkuName, OrpSku updatedOrpSku)
        {
            using (var ctx = new OrpSkuInventoryEntities())
            {
                var foundSku = GetSkuInventoryRecord(ctx, orpSkuName);
                if (foundSku == null)
                    return;

                foundSku.ID = updatedOrpSku.OrpSkuId;
                foundSku.Item_Description = updatedOrpSku.OrpSkuDescription;
                foundSku.Item_Number = updatedOrpSku.OrpSkuName;
                foundSku.InUse = updatedOrpSku.InUse.ToString();
                foundSku.Term = updatedOrpSku.Term;
                foundSku.Product = updatedOrpSku.Product;
                foundSku.SkuPrice = (decimal?)updatedOrpSku.SkuPrice;
                foundSku.MsrpPrice = (decimal?)updatedOrpSku.MsrpPrice;

                ctx.SaveChanges();
            }
        }

        #region Private Methods

        private OrpSku GetOrpSkuFromSkuInventory(SkuInventoryDb skuInventory)
        {
            var orpSku = new OrpSku()
            {
                OrpSkuId = skuInventory.ID,
                OrpSkuName = skuInventory.Item_Number,
                OrpSkuDescription = skuInventory.Item_Description,
                InUse = skuInventory.InUse,
                Term = skuInventory.Term.Value,
                Product = skuInventory.Product,
                SkuPrice = skuInventory.SkuPrice,
                MsrpPrice = skuInventory.MsrpPrice
            };
            return orpSku;
        }


        private SkuInventoryDb GetSkuInventoryRecord(OrpSkuInventoryEntities ctx, string orpSkuName)
        {
            SkuInventoryDb foundSku = null;
            foundSku = (from s in ctx.SkuInventoryDbs
                        where s.Item_Number.Equals(orpSkuName)
                        select s).FirstOrDefault();
            return foundSku;
        }

        #endregion
    }
}
