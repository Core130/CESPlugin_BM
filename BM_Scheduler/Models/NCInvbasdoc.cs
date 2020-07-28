using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BM_Scheduler.Models
{
    /// <summary>
    /// 物料档案
    /// </summary>
    public class NCInvbasdoc
    {
        /// <summary>
        /// 存货档案主键
        /// </summary>
        public string pk_invbasdoc { get; set; }
        /// <summary>
        /// 存货管理档案主键
        /// </summary>
        public string pk_invmandoc { get; set; }
        /// <summary>
        /// 存货编码
        /// </summary>
        public string invcode { get; set; }
        /// <summary>
        /// 存货名称
        /// </summary>
        public string invname { get; set; }
        /// <summary>
        /// 存货简称
        /// </summary>
        public string invshortname { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string invspec { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string invtype { get; set; }
        /// <summary>
        /// 主计量单位主键
        /// </summary>
        public string pk_measdoc { get; set; }
        public DateTime ts { get; set; }
        public DateTime? DModify { get; set; }
        public int state { get; set; }

    }
    /// <summary>
    /// NC价格表明细
    /// </summary>
    public class NCTariffItem
    {
        /// <summary>
        /// 存货管理档案ID
        /// </summary>
        public string cinventoryid { get; set; }
        /// <summary>
        /// 价格项1
        /// </summary>
        public decimal? nprice1 { get; set; }

        public DateTime ts { get; set; }
        public DateTime? DModify { get; set; }
        public int state { get; set; }
    }
    /// <summary>
    /// NC计量单位
    /// </summary>
    public class NCMeasdoc
    {
        /// <summary>
        /// 计量档案主键
        /// </summary>
        public string pk_measdoc { get; set; }
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string measname { get; set; }
        /// <summary>
        /// 计量单位简称
        /// </summary>
        public string shortname { get; set; }
        public DateTime ts { get; set; }
        public DateTime? DModify { get; set; }
        public int state { get; set; }
    }

    /// <summary>
    /// 返回消息
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 1为成功
        /// </summary>
        public string success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 成功消息
        /// </summary>
        public string message { get; set; }
    }
}