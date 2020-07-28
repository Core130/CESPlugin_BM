using System;
using System.Diagnostics;
using System.Text;

namespace BM_Scheduler.Models
{
    public class LogTraceListener : DefaultTraceListener
    {
        private string _path;
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("zh-CN");

        public LogTraceListener(string dir)
            : base()
        {
            _path = System.AppDomain.CurrentDomain.BaseDirectory + dir + "\\";
            if (!System.IO.Directory.Exists(_path)) System.IO.Directory.CreateDirectory(_path);
        }

        public override void Write(string message)
        {

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_path + "商品档案" + DateTime.Now.ToString("yyyyMMdd", ci.DateTimeFormat) + ".html",true, Encoding.Default))
            {
                sw.Write("<br /><br />------------------------------<br />[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", ci.DateTimeFormat) + "]\t" + message);
            }
        }

        public override void WriteLine(string message)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_path + "商品档案" + DateTime.Now.ToString("yyyyMMdd", ci.DateTimeFormat) + ".html", true, Encoding.Default))
            {
                sw.WriteLine("<br /><br />------------------------------<br />[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", ci.DateTimeFormat) + "]\t" + message);
            }
        }
    }
}
