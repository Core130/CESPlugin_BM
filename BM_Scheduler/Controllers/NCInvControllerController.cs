using BM_Scheduler.Handle;
using BM_Scheduler.Models;
using BM_Scheduler.Scheduler;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BM_Scheduler.Controllers
{
    public class NCInvController : Controller
    {
       

        public void Execute()
        {
            try
            {
                var myjob = new InvJob();
                myjob.UpdateInvAll();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("商品档案对接发生异常:" + ex.Message.ToString() + ex.StackTrace);

            }

        }

    }
}