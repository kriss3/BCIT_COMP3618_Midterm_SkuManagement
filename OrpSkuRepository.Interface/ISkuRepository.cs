using OrpSkuViewer.SharedObjects;
using System.Collections.Generic;

namespace OrpSkuRepository.Interface
{
    public interface ISkuRepository
    {
        IEnumerable<OrpSku> GetAllSku();

        OrpSku GetSkuByName(string orpSkuName);

        OrpSku GetSkuById(int orpSkuId);

        void AddSku(OrpSku newOrpSku);

        void UpdateSku(string orpSkuName, OrpSku updatedOrpSku);

        void DeleteSku(string orpSkuName);

        void UpdateAllSku(IEnumerable<OrpSku> updatedOrpSku);
    }
}
