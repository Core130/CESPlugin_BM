using App.Plugin_BM.AppServices;
using CES.Core.Cache;
using CES.Core.Common;
using CES.Core.Controllers;
using Da.CESPlugin_BM;
using Da.Core.Aggregates;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.CESPlugin_BM
{
    public class P_BM_DocImageDetailController : BaseController
    {
        P_BM_DocImageDetailAppServices appSvr;
        public P_BM_DocImageDetailController()
        {
            appSvr = new P_BM_DocImageDetailAppServices();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询单据影像清单
        /// </summary>
        /// <returns></returns>
        public ActionResult Search([DataSourceRequest] DataSourceRequest request, string CompanyCode,string DateFm, string DateTo)
        {
            var data = appSvr.GetDocImageDetail(CompanyCode,DateFm, DateTo);
            return Json(data.ToDataSourceResult(request));
        }

        /// <summary>
        /// 导出单据影像清单
        /// </summary>
        /// <returns></returns>
        public ActionResult Export([DataSourceRequest] DataSourceRequest request, string CompanyCode, string DateFm, string DateTo)
        {
            var prgID = "P_BM_01";
            var fields = CacheDataManager.GetAllFields().Where(p => p.PrgID == prgID).ToList();
            var curUserID = CurUserInfo.GetCurUserID;
            var userConfigInfo = CacheDataManager.GetAllUserConfig().FirstOrDefault(p => p.UserID == curUserID && p.PrgID == prgID);
            if (userConfigInfo == null) userConfigInfo = CacheDataManager.GetAllUserConfig().FirstOrDefault(p => p.UserID == "all" && p.PrgID == prgID);
            var tempDisplayFields = new string[] { };
            if (userConfigInfo != null) tempDisplayFields = userConfigInfo.DisplayFields.Split(',');
            var displayFields = new List<DD_Field>();
            foreach (var item in tempDisplayFields)
            {
                var temp = fields.FirstOrDefault(p => item == p.DisplayName && p.Kind == "Doc");
                if (temp != null) displayFields.Add(temp);
            }
            var data = appSvr.GetDocImageDetail(CompanyCode, DateFm, DateTo);
            return FillDataToExcel(string.Join(",", displayFields.Select(p => p.DisplayName).ToArray()), string.Join(",", displayFields.Select(p => p.Descr).ToArray()), prgID, (List<P_BM_DocImageDetail>)data.ToDataSourceResult(request).Data);
        }
    }
}