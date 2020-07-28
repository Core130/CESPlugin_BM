using BM_Scheduler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BM_Scheduler.Handle
{
    public class NCInvbasdoc_Handle : BaseHandle
    {
        public int GetInvbasdoc(DateTime ds, int page, int size)
        {
            var dataList = new List<NCInvbasdoc>();
            string res = GET(geturl(), getmaps(ds, page, size));            
            if (!string.IsNullOrWhiteSpace(res))
            {
                var temp = Newtonsoft.Json.Linq.JObject.Parse(res);
                if (temp != null)
                {

                    if (temp["success"].ToObject<int>() == 1)
                    {

                        var jsonStr = temp["message"].ToString();
                        if (!string.IsNullOrWhiteSpace(jsonStr))
                        {
                            dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NCInvbasdoc>>(jsonStr);
                        }
                    }
                    else
                    {
                        Trace.WriteLine(temp.ToString());
                        return -1;
                    }
                }
            }
            if (dataList.Count == 0)
            {
                return 0;
            }
            UpdateInvbasdoc(dataList);
            return 1;
        }
        public void UpdateInvbasdoc(List<NCInvbasdoc> dataList)
        {
            string sql = @"IF NOT EXISTS(SELECT 1 FROM Bama_NCInvbasdoc WHERE pk_invmandoc = @pk_invmandoc)
                            INSERT INTO Bama_NCInvbasdoc(pk_invbasdoc, pk_invmandoc, invcode, invname,
                            invshortname, invspec, invtype, pk_measdoc, ts, DModify, iState)
                            VALUES(@pk_invbasdoc, @pk_invmandoc, @invcode, @invname,
                            @invshortname, @invspec, @invtype, @pk_measdoc, @ts, @DModify, @iState)
                            ELSE(
	                            UPDATE Bama_NCInvbasdoc 
	                            SET pk_invbasdoc=@pk_invbasdoc,	invcode =@invcode,	invname=@invname,invshortname=@invshortname,
	                            invspec=@invspec,invtype=@invtype,pk_measdoc=@pk_measdoc,ts=@ts,DModify=@DModify,iState=@iState
	                            WHERE pk_invmandoc = @pk_invmandoc
                        )";
            for (int i =0; i <= dataList.Count;i++)
            {
                SqlParameter[] paras =
                {
                 new SqlParameter("@pk_invmandoc",dataList[i].pk_invmandoc.ToString()),
                 new SqlParameter("@pk_invbasdoc",dataList[i].pk_invbasdoc.ToString()),
                 new SqlParameter("@invcode",dataList[i].invcode.ToString()),
                 new SqlParameter("@invname",dataList[i].invname.ToString()),
                 new SqlParameter("@invshortname",dataList[i].invshortname.ToString()),
                 new SqlParameter("@invspec",dataList[i].invspec.ToString()),
                 new SqlParameter("@invtype",dataList[i].invtype.ToString()),
                 new SqlParameter("@pk_measdoc",dataList[i].pk_measdoc.ToString()),
                 new SqlParameter("@ts",dataList[i].ts.ToString()),
                 new SqlParameter("@DModify",DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")),
                 new SqlParameter("@iState","0"),                
            };
                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
            }
        }

        public  string geturl()
        {
            return GetValue("URL", "NCURL");
            //+ @"?c=apidata&m=api&org=1&name=GetNCBdCorp &type=json&key=bamatea"
        }
        public  Dictionary<string, string> getmaps(DateTime ds, int page, int size)
        {
            var dic = new Dictionary<string, string>();
            var maps = new Dictionary<string, string>();
            dic.Add("ts", ds.ToString("yyyy-MM-dd HH:mm:ss"));
            maps.Add("c", "apidata");
            maps.Add("m", "api");
            maps.Add("org", "1");
            maps.Add("name", "GetNCInvbasdoc");
            maps.Add("type", "json");
            maps.Add("key", "bamatea");
            maps.Add("attr", JsonConvert.SerializeObject(dic));
            maps.Add("page", page.ToString());
            maps.Add("size", size.ToString());
            return maps;
        }
    }
}