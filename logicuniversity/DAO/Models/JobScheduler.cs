using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace logicuniversity.Models
{
    public class JobScheduler
    {

        public static void Start()
        {



            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            IJobDetail job = JobBuilder.Create<CheckDeldateChangeJob>().Build();
            scheduler.Start();
           

            ITrigger trigger = TriggerBuilder.Create()
        .WithIdentity("myTrigger", "group1")
        .StartNow()
        .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                   .RepeatForever())
           .Build();



            scheduler.ScheduleJob(job, trigger);





        }

    }

}



