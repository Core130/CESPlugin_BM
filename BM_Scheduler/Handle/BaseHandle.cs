using BM_Scheduler.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml;

namespace BM_Scheduler.Handle
{
    public class BaseHandle
    {
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="requestString">参数</param>
        /// <param name="method">请求方式(get或post)</param>
        /// <returns></returns>
        public string SendRequest(string url, string requestString, string method)
        {
            var responseString = string.Empty;
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpRequest.Method = method;
            httpRequest.KeepAlive = true;
            httpRequest.Accept = "text/html, application/xhtml+xml, */*";
            httpRequest.ContentType = "application/json";
            if (!string.IsNullOrEmpty(requestString))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(requestString);
                httpRequest.ContentLength = bytes.Length;
                //获得请 求流
                Stream writer = httpRequest.GetRequestStream();
                //将请求参数写入流
                writer.Write(bytes, 0, bytes.Length);
                // 关闭请求流
                writer.Close();
            }
            else
            {
                httpRequest.ContentLength = 0;
            }
            Stream requestStream = httpRequest.GetResponse().GetResponseStream();
            using (StreamReader sr = new StreamReader(requestStream, Encoding.UTF8))
            {
                responseString = sr.ReadToEnd();
            }

            return responseString;
        }

        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            Trace.WriteLine(url + builder.ToString());
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        /// <summary>
        /// 无参数POST
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Post(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();           
            Trace.WriteLine(url);

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        //public static string Post(string url, Dictionary<string, string> dic)
        //{
        //    string result = "";
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        //    req.Method = "POST";
        //    req.Accept = "text/html, application/xhtml+xml, */*"; ;
        //    req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

        //    #region 添加Post 参数
        //    StringBuilder builder = new StringBuilder();
        //    int i = 0;
        //    foreach (var item in dic)
        //    {
        //        if (i > 0)
        //            builder.Append("&");
        //        builder.AppendFormat("{0}={1}", item.Key, item.Value);
        //        i++;
        //    }


        //    byte[] data = Encoding.UTF8.GetBytes(String2Unicode(builder.ToString()));
        //    req.ContentLength = data.Length;
        //    using (Stream reqStream = req.GetRequestStream())
        //    {
        //        reqStream.Write(data, 0, data.Length);
        //        reqStream.Close();
        //    }
        //    #endregion
        //    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        //    Stream stream = resp.GetResponseStream();
        //    //获取响应内容
        //    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //    {
        //        result = reader.ReadToEnd();
        //    }
        //    return Unicode2String(result);
        //}

        public static string UrlEncode(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in str)
            {
                if (HttpUtility.UrlEncode(c.ToString()).Length > 1)
                {
                    builder.Append(HttpUtility.UrlEncode(c.ToString()).ToUpper());
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// POST方法 函数重载
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string Post(string url, string dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Accept = "text/html, application/xhtml+xml, */*";
            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            //req.ContentType = "text/xml; charset=UTF-8";
            //req.ContentType = "application/json; charset=UTF-8";
            #region 添加Post 参数
            Trace.WriteLine(url + dic);

            //byte[] data = Encoding.Default.GetBytes(UrlEncode(dic));
            byte[] data = Encoding.UTF8.GetBytes(dic);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException ex)
            {
                resp = (HttpWebResponse)ex.Response;
                Trace.WriteLine("错误异常:" + ex.Message + ex.InnerException);
                Trace.WriteLine("错误异常:" + ex.HResult + ex.Response);
            }
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
            //return System.Web.HttpUtility.UrlDecode(result);
        }
        public static void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback
                       += RemoteCertificateValidate;
        }

        /// <summary>
        /// Remotes the certificate validate.
        /// </summary>
        private static bool RemoteCertificateValidate(
           object sender, X509Certificate cert,
            X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }

        /// <summary>
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="s">开始</param>
        /// <param name="e">结束</param>
        /// <returns></returns> 
        public static string GetMassge(string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }
        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        internal static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }
        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                         source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }

        public static string GET(string url, Dictionary<string, string> dic)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            Trace.WriteLine(url + builder.ToString());

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url + builder.ToString());
            req.Method = "GET";
            req.Accept = "text/html, application/xhtml+xml, */*";
            req.ContentType = "application/json";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return Unicode2String(result);
        }
        /// <summary>
        /// 获取大写编码字符串
        /// </summary>
        private static string GetUpperEncode(string encode)
        {
            var result = new StringBuilder();
            int index = int.MinValue;
            for (int i = 0; i < encode.Length; i++)
            {
                string character = encode[i].ToString();
                if (character == "%")
                    index = i;
                if (i - index == 1 || i - index == 2)
                    character = character.ToUpper();
                result.Append(character);
            }
            return result.ToString();
        }

        /// <summary>
        /// 字段赋值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t1">类1</param>
        /// <param name="t2">类2</param>
        /// <param name="param">忽略赋值的字段</param>
        public void Mapper<T>(T t1, T t2, params string[] param)
        {
            try
            {
                var sType = t1.GetType();
                var dType = t2.GetType();
                foreach (PropertyInfo sP in sType.GetProperties())
                {
                    foreach (PropertyInfo dP in dType.GetProperties())
                    {
                        if (dP.Name == sP.Name)
                        {
                            if (param.Contains(dP.Name))
                            {
                                continue;
                            }
                            dP.SetValue(t2, sP.GetValue(t1));
                            break;
                        }
                    }
                }
            }
            catch (Exception )
            {

            }
        }

        /// <summary>
        /// 数据处理
        /// </summary>
        public virtual void DataHandle(string updatetime)
        {
        }


        public string geturl(string url)
        {
            //return ConfigurationManager.AppSettings["slurl"] +  url;
            return GetValue("DS", "slurl") + url;
        }

        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="msg"></param>
        public void SaveInfoLogs(string msg)
        {
            try
            {
                //string directory = Environment.CurrentDirectory + "\\Logs\\Info";
                string directory = "D:\\Logs\\Info";
                string fileName = GetFileName(directory, DateTime.Now.ToString("yyyy-MM-dd") + "_Info.txt");

                string path = string.Format("{0}\\{1}", directory, fileName);
                File.AppendAllText(path, msg + "\r\n\r\n");
            }
            catch (Exception )
            {
                // 日志文件创建失败时，不能报错
            }
        }

        /// <summary>
        /// 获取日志文件名
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetFileName(string directory, string fileName)
        {
            /*
             * 文件名规则
             * 按日期创建文件，一天一个，如果当天的日志文件大于20M，则新建一个
             * 
             */

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            FileInfo file = new FileInfo(directory + "\\" + fileName);
            if (file.Exists)
            {
                if (file.Length / (1024 * 1024) >= 20)
                {
                    string[] fnsplit = fileName.Split('.');


                    fileName = string.Format("{0}1.txt", fnsplit[0]);

                    if (File.Exists(directory + "\\" + fileName))
                    {
                        fileName = GetFileName(directory, fileName);
                    }
                }
            }

            return fileName;
        }

        [DllImport("kernel32")]
        //  读配置文件方法的6个参数：所在的分区（section）、键值、     初始缺省值、     StringBuilder、   参数长度上限、配置文件路径
        private static extern int GetPrivateProfileString(string section, string key, string deVal, StringBuilder retVal,
            int size, string filePath);
        [DllImport("kernel32")]
        // 写配置文件方法的4个参数：所在的分区（section）、  键值、     参数值、        配置文件路径
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static void SetValue(string section, string key, string value)
        {
            StringBuilder sb = new StringBuilder(255);
            string str = Assembly.GetExecutingAssembly().CodeBase;
            int start = 8;// 去除file:///  
            int end = str.LastIndexOf('/');// 去除文件名xxx.dll及文件名前的/  
            str = str.Substring(start, end - start);
            //获得当前路径，当前是在Debug路径下
            // string strPath = Environment.CurrentDirectory + "\\system.ini";
            WritePrivateProfileString(section, key, value, str + @"\CESInt.ini");
        }
        public static string GetValue(string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            string str = Assembly.GetExecutingAssembly().CodeBase;
            int start = 8;// 去除file:///  
            int end = str.LastIndexOf('/');// 去除文件名xxx.dll及文件名前的/  
            str = str.Substring(start, end - start);

            //string strPath = System.IO.File.ReadAllText(str + @"\DS.ini");
            //string strPath = (str + @"/DS.ini").Replace(@"/",@"//");
            //最好初始缺省值设置为非空，因为如果配置文件不存在，取不到值，程序也不会报错
            GetPrivateProfileString(section, key, "配置文件不存在，未取到参数", sb, 255, str + @"\CESInt.ini");
            return sb.ToString();

        }
        /// <summary>
        /// 获取上次更新时间
        /// </summary>
        /// <param name="sytime"></param>
        /// <returns></returns>
        public static string getxmlvalue(string sytime)
        {
            string result;
            string sql = @"SELECT TOP 1 sytime FROM Bama_NCTime WHERE syName = @syName";
            SqlParameter[] paras =
                {
                new SqlParameter("@syName",sytime),
            };
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.Text, sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                result = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            }
            return result;
        }
        /// <summary>
        /// 修改最大同步时间
        /// </summary>
        /// <param name="sytime"></param>
        /// <param name="vlues"></param>
        public static void setxmlvalue(string syName, string tableName)
        {            
            string sql = string.Format(@"UPDATE Bama_NCTime SET sytime = ISNULL((SELECT MAX(ts) FROM {1}),GETDATE()) WHERE syName = '{0}'", syName, tableName);
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

    }

}