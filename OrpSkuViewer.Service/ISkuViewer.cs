using OrpSkuViewer.SharedObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace OrpSkuViewer.Service
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Interface for WCF service;
    /// </summary>
    [ServiceContract]
    public interface ISkuViewer
    {
        [OperationContract]
        IEnumerable<OrpSku> GetAllSku();
        [OperationContract]
        OrpSku GetSkuByName(string orpSkuName);
        [OperationContract]
        OrpSku GetSkuById(int orpSkuId);
        [OperationContract]
        void AddSku(OrpSku newOrpSku);
        [OperationContract]
        void UpdateSku(string orpSkuName, OrpSku updatedOrpSku);
        [OperationContract]
        void DeleteSku(string orpSkuName);
    }
}
