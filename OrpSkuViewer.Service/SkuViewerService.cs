using OrpSkuRepository.Sql;
using OrpSkuViewer.SharedObjects;
using System.Collections.Generic;

namespace OrpSkuViewer.Service
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: WCF service supporting CRUD operations;
    /// This service CAN be tested on its own => passthrough to the SQL Repository (DB operations)
    /// </summary>
    public class SkuViewerService : ISkuViewer
    {
        private SqlRepository _repo;
        public SkuViewerService()
        {
            _repo = new SqlRepository();
        }

        public void AddSku(OrpSku newOrpSku)
        {
            _repo.AddSku(newOrpSku);
        }

        public void DeleteSku(string orpSkuName)
        {
            _repo.DeleteSku(orpSkuName);
        }

        public IEnumerable<OrpSku> GetAllSku()
        {
            return _repo.GetAllSku();
        }

        public OrpSku GetSkuById(int orpSkuId)
        {
            return _repo.GetSkuById(orpSkuId);
        }

        public OrpSku GetSkuByName(string orpSkuName)
        {
            return _repo.GetSkuByName(orpSkuName);
        }

        public void UpdateSku(string orpSkuName, OrpSku updatedOrpSku)
        {
            _repo.UpdateSku(orpSkuName, updatedOrpSku);
        }
    }
}
