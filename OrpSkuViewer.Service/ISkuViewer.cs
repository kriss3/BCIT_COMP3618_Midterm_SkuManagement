using OrpSkuViewer.SharedObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace OrpSkuViewer.Service
{
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
