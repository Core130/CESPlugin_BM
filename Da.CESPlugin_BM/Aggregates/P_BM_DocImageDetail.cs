using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da.CESPlugin_BM
{
    /// <summary>
    /// 单据影像清单
    /// </summary>
    public class P_BM_DocImageDetail : Entity
    {
        /// <summary>
        /// 归属公司
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 程序编码
        /// </summary>
        public string PrgID { get; set; }
        /// <summary>
        /// 单据类型
        /// </summary>
        public string PrgName { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        public string DataNbr { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime DocDate { get; set; }
        /// <summary>
        /// 单据金额
        /// </summary>
        public decimal TotalCost { get; set; }
        /// <summary>
        /// 影像上传时间
        /// </summary>
        public DateTime ImgCrtDate { get; set; }  
        /// <summary>
        /// 单据状态
        /// </summary>
        public string DocStatus { get; set; }
    }
}
