using OrpSkuRepository.Interface;
using OrpSkuViewer.SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrpSkuRepository.Local
{
    public class LocalRepository : ISkuRepository
    {
        private List<OrpSku> _localRepo = new List<OrpSku>();

        public LocalRepository()
        {
            _localRepo = new List<OrpSku>()
            {
                new OrpSku{ OrpSkuId = 0, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 1, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 2, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 3, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 4, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 5, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 5, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 6, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 7, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 8, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 9, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 10, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 11, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m },
                new OrpSku{ OrpSkuId = 12, OrpSkuName = "", OrpSkuDescription = "", InUse="Y" , Term = 12, Product = "", SkuPrice = 12.99m, MfnFloorPrice=12.99m, MsrpPrice = 12.99m }
            };
        }

        public IEnumerable<OrpSku> GetAllSku()
        {
            return this._localRepo;
        }

        public OrpSku GetSkuById(int orpSkuId)
        {
            return _localRepo.Where(x => x.OrpSkuId == orpSkuId).FirstOrDefault();
        }

        public OrpSku GetSkuByName(string orpSkuName)
        {
            return _localRepo.Where(x=>x.OrpSkuName.Equals(orpSkuName)).FirstOrDefault();
        }

        public void AddSku(OrpSku newOrpSku)
        {
            _localRepo.Add(newOrpSku);
        }

        public void DeleteSku(string orpSkuName)
        {
            var skuToRemove = _localRepo.Where(x=>x.OrpSkuName.Equals(orpSkuName)).FirstOrDefault();
            _localRepo.Remove(skuToRemove);
        }

        public void UpdateSku(string orpSkuName, OrpSku updatedOrpSku)
        {
            var skuToUpdate = _localRepo.Where(x=>x.OrpSkuName.Equals(orpSkuName)).FirstOrDefault();
            skuToUpdate.OrpSkuId = updatedOrpSku.OrpSkuId;
            skuToUpdate.OrpSkuName = updatedOrpSku.OrpSkuName;
            skuToUpdate.OrpSkuDescription = updatedOrpSku.OrpSkuDescription;
            skuToUpdate.InUse = updatedOrpSku.InUse;
            skuToUpdate.Product = updatedOrpSku.Product;
            skuToUpdate.Term = updatedOrpSku.Term;
            skuToUpdate.SkuPrice = updatedOrpSku.SkuPrice;
            skuToUpdate.MsrpPrice = updatedOrpSku.MsrpPrice;
            skuToUpdate.MfnFloorPrice = updatedOrpSku.MfnFloorPrice;
        }
    }
}
