using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrpSkuViewer.SharedObjects;
using OrpSkuViewer.ViewModel;
using Quartz;

namespace OrpSkuViewer.View.Scheduler
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: SimpleJob class implements IJob interface and Execute method that will actually do the job of setting viewModel property
    /// </summary>
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
