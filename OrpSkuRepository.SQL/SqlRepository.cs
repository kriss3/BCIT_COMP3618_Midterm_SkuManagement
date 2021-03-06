﻿using OrpSkuRepository.Interface;
using OrpSkuViewer.SharedObjects;
using System.Collections.Generic;
using System.Linq;

namespace OrpSkuRepository.Sql
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: SQL Repository class to support database CRUD operations;
    /// Implements common ISkuRepository;
    /// </summary>
    public class SqlRepository : ISkuRepository
    {
        #region Public CRUD Methods
        public void AddSku(OrpSku newOrpSku)
        {
            using (var ctx = new SkuInventoryEntities())
            {
                if (getSkuInventoryRecord(ctx, newOrpSku.OrpSkuName) != null)
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
            using (var ctx = new SkuInventoryEntities())
            {
                var foundSku = getSkuInventoryRecord(ctx, orpSkuName);
                if (foundSku == null)
                    return;

                ctx.SkuInventoryDbs.Remove(foundSku);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<OrpSku> GetAllSku()
        {
            using (var ctx = new SkuInventoryEntities())
            {
                var orpSkus = (from s in ctx.SkuInventoryDbs
                              select new OrpSku
                              {
                                  OrpSkuId = s.ID,
                                  OrpSkuDescription = s.Item_Description,
                                  OrpSkuName = s.Item_Number,
                                  Comment = s.Comment,
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
            using (var ctx = new SkuInventoryEntities())
            {
                var skuResult = (from s in ctx.SkuInventoryDbs
                                 where s.ID == orpSkuId
                                 select new OrpSku
                                 {
                                     OrpSkuId = s.ID,
                                     OrpSkuName = s.Item_Number,
                                     OrpSkuDescription = s.Item_Description,
                                     Comment = s.Comment,
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

            using (var ctx = new SkuInventoryEntities())
            {
                var foundSku = getSkuInventoryRecord(ctx, orpSkuName);
                if (foundSku != null)
                    orpSku = getOrpSkuFromSkuInventory(foundSku);
            }
            return orpSku;
        }

        public void UpdateSku(string orpSkuName, OrpSku updatedOrpSku)
        {
            using (var ctx = new SkuInventoryEntities())
            {
                var foundSku = getSkuInventoryRecord(ctx, orpSkuName);
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
                foundSku.Comment = updatedOrpSku.Comment;

                ctx.SaveChanges();
            }
        }
#endregion

        #region Private Methods

        private OrpSku getOrpSkuFromSkuInventory(SkuInventoryDb skuInventory)
        {
            var orpSku = new OrpSku()
            {
                OrpSkuId = skuInventory.ID,
                OrpSkuName = skuInventory.Item_Number,
                OrpSkuDescription = skuInventory.Item_Description,
                Comment = skuInventory.Comment,
                InUse = skuInventory.InUse,
                Term = skuInventory.Term.Value,
                Product = skuInventory.Product,
                SkuPrice = skuInventory.SkuPrice,
                MsrpPrice = skuInventory.MsrpPrice
            };
            return orpSku;
        }
        private SkuInventoryDb getSkuInventoryRecord(SkuInventoryEntities ctx, string orpSkuName)
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
