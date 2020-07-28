using BM_Scheduler.Handle;
using BM_Scheduler.Scheduler;
using Quartz;
using Quartz.Impl;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Routing;
namespace BM_Scheduler
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //同步时间(分钟)
            var syncTime = ConfigurationManager.AppSettings["CESArchivesJob"];
            //是否开启同步
            var bTask = ConfigurationManager.AppSettings["TaskIsSynchro"];
            if (bTask == "1")
            {
                //创建任务           
                var invJob = JobBuilder.Create<InvJob>().WithIdentity("Invjob", "group4").Build();

                Trace.WriteLine("商品档案对接开始启动...");

                //创建触发器
                var trigger = TriggerBuilder.Create()
                    .WithIdentity("Invjob", "group4")
                    .WithCronSchedule("0 0/" + syncTime + " * * * ?")
                    .StartNow()
                    .Build();

                //调度器工厂
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                //将触发器添加到调度器中           
                scheduler.ScheduleJob(invJob, trigger);
                //启动调度器
                scheduler.Start();
            }
        }
    }
}