using OrpSkuViewer.SharedObjects;
using System.Collections.Generic;

namespace OrpSkuRepository.Interface
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Common CRUD operation repository; each new repo should implemented this interface;
    /// </summary>
    public interface ISkuRepository
    {
        IEnumerable<OrpSku> GetAllSku();

        OrpSku GetSkuByName(string orpSkuName);

        OrpSku GetSkuById(int orpSkuId);

        void AddSku(OrpSku newOrpSku);

        void UpdateSku(string orpSkuName, OrpSku updatedOrpSku);

        void DeleteSku(string orpSkuName);
    }
}
