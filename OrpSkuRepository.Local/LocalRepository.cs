using OrpSkuRepository.Interface;
using OrpSkuViewer.SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrpSkuRepository.Local
{
    public class LocalRepository : ISkuRepository
    {
        public void AddSku(OrpSku newOrpSku)
        {
            throw new NotImplementedException();
        }

        public void DeleteSku(string orpSkuName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrpSku> GetAllSku()
        {
            throw new NotImplementedException();
        }

        public OrpSku GetSkuById(int orpSkuId)
        {
            throw new NotImplementedException();
        }

        public OrpSku GetSkuByName(string orpSkuName)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllSku(IEnumerable<OrpSku> updatedOrpSku)
        {
            throw new NotImplementedException();
        }

        public void UpdateSku(string orpSkuName, OrpSku updatedOrpSku)
        {
            throw new NotImplementedException();
        }
    }
}
