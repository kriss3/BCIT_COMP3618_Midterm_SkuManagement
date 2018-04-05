using Quartz;
using Quartz.Impl;

namespace OrpSkuViewer.View.Scheduler
{
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
