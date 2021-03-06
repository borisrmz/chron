﻿using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chrone
{
    class Program
    {
        static void Main(string[] args)
        {
            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler, start the schedular before triggers or anything else
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            // create job
            IJobDetail job = JobBuilder.Create<SimpleJob>()
                        .WithIdentity("job1", "group1")
                        .Build();

            // create trigger
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            // Schedule the job using the job and trigger 
            sched.ScheduleJob(job, trigger);

        }
    }

    /// &lt;summary&gt;
    /// SimpleJOb is just a class that implements IJOB interface. It implements just one method, Execute method
    /// &lt;/summary&gt;
    public class SimpleJob : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Hello, JOb executed");
            Console.BackgroundColor = ConsoleColor.White;
        }
    }



    
}
