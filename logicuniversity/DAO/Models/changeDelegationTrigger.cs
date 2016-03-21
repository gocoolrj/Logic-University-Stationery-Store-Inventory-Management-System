using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using Quartz.Job;
namespace logicuniversity.Models
{
    public class changeDelegationTrigger
    {
        IScheduler sched = StdSchedulerFactory.GetDefaultScheduler();
        public void triggerNow(int emp_id)
        {
            // sched.Start();
            //  JobDataMap data = context.getJobDetail().getJobDataMap();
            //       IJobDetail job = JobBuilder.Create<changeDelegation>()
            //.WithIdentity("myJob", "group1")
            //.Build();

            IJobDetail job = JobBuilder.Create<changeDelegation>()
    .WithIdentity("myJob", "group1") // name "myJob", group "group1"
    .UsingJobData("emp_id", emp_id)
    .Build();

            // much neededITrigger trigger = TriggerBuilder.Create()
            //     .WithIdentity("myTrigger", "group1").StartAt(System.DateTime.Today.AddDays(1))
            //.Build();
            ITrigger trigger = TriggerBuilder.Create()
          .WithIdentity("myTrigger", "myTriggerGroup")
          .StartNow()
          .WithSimpleSchedule(x => x
              .WithIntervalInSeconds(40)
              .RepeatForever())
          .Build();

            sched.ScheduleJob(job, trigger);
        }

    }
}