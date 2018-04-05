using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrpSkuViewer.SharedObjects;
using OrpSkuViewer.ViewModel;
using Quartz;

namespace OrpSkuViewer.View.Scheduler
{
    public class SimpleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var schedulerContext = context.Scheduler.Context;
            var skuList = (OrpSkuViewerViewModel)schedulerContext.Get("key1");

            return Task.Run(() =>
            {
                //set the valie of skiIList to new ObservableCollection<OrpSku>
                skuList.AllSku = new ObservableCollection<OrpSku>();
                
            });
        }
    }
}
