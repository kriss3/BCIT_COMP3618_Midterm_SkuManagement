using Quartz;
using Quartz.Impl;

namespace OrpSkuViewer.View.Scheduler
{
    /// <summary>
    /// BCIT COMP3618 
    /// Krzysztof Szczurowski Midterm Project
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
    /// Description: Setup class containing executable async running method Run()
    /// Run method will simply set base viewModel AllSku property to an empty ObservableCollection<OrpSku>
    /// This class contains configuration of interval, how often the job will repeat;
    /// </summary>
    public class Config
    {
        public static async void Run(OrpSkuViewer.ViewModel.OrpSkuViewerViewModel vm)
        {
            //Construct scheduler factory;
            ISchedulerFactory schFactory = new StdSchedulerFactory();

            IScheduler scheduler = await schFactory.GetScheduler(new System.Threading.CancellationToken());
            scheduler.Context.Put("key1", vm);
            await scheduler.Start();

            //Job
            IJobDetail jobDetail = JobBuilder.Create<SimpleJob>().WithIdentity("job1", "group1").Build();

            //Trigger
            ITrigger jobTrigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(20).RepeatForever())
                .Build();

            //schedule
            await scheduler.ScheduleJob(jobDetail, jobTrigger);
        }
    }
}
