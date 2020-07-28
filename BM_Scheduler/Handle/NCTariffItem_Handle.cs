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
    public class NCTariffItem_Handle : BaseHandle
    {
        public int GetNCTariffItem(DateTime ds, int page, int size)
        {
            var dataList = new List<NCTariffItem>();
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
                            dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NCTariffItem>>(jsonStr);
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

            UpdateNCTariffItem(dataList);


            return 1;
        }
        public void UpdateNCTariffItem(List<NCTariffItem> dataList)
        {
            string sql = @"IF NOT EXISTS(SELECT 1 FROM Bama_NCTariffItem WHERE cinventoryid = @cinventoryid)
                            INSERT INTO Bama_NCTariffItem(cinventoryid, nprice1,ts, DModify,iState )
                            VALUES(@cinventoryid, @nprice1,@ts, @DModify, @iState)
                            ELSE(
	                            UPDATE Bama_NCTariffItem 
	                            SET nprice1=@nprice1,ts=@ts,DModify=@DModify,iState=@iState
	                            WHERE cinventoryid = @cinventoryid
                            )";
            for (int i = 0; i <= dataList.Count; i++)
            {
                SqlParameter[] paras =
                {
                 new SqlParameter("@cinventoryid",dataList[i].cinventoryid.ToString()),
                 new SqlParameter("@nprice1",dataList[i].nprice1.ToString()),                
                 new SqlParameter("@ts",dataList[i].ts.ToString()),
                 new SqlParameter("@DModify",DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")),
                 new SqlParameter("@iState","0"),
            };
                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, paras);
            }

        }

        public string geturl()
        {
            return GetValue("URL", "NCURL");
            //+ @"?c=apidata&m=api&org=1&name=GetNCBdCorp &type=json&key=bamatea"
        }
        public Dictionary<string, string> getmaps(DateTime ds, int page, int size)
        {
            var dic = new Dictionary<string, string>();
            var maps = new Dictionary<string, string>();
            dic.Add("ts", ds.ToString("yyyy-MM-dd HH:mm:ss"));
            maps.Add("c", "apidata");
            maps.Add("m", "api");
            maps.Add("org", "1");
            maps.Add("name", "GetNCTariffItem");
            maps.Add("type", "json");
            maps.Add("key", "bamatea");
            maps.Add("attr", JsonConvert.SerializeObject(dic));
            maps.Add("page", page.ToString());
            maps.Add("size", size.ToString());
            return maps;
        }
    }
}