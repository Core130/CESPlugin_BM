using Da.Plugin_BM;
using Infrastructure;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Da.CESPlugin_BM.Repository
{
    public class P_BM_DocImageDetailRepository : Repository<P_BM_DocImageDetail>
    {
        public P_BM_DocImageDetailRepository(IMainBCUnitOfWork uow)
            : base(uow)
        {

        }

        public List<P_BM_DocImageDetail> GetDocImageDetail(string CompanyCode, string DateFm, string DateTo)
        {
            var curuow = UnitOfWork as MainBCUnitOfWork;
            string sql = string.Format(@"SELECT c.PrgID, d.CompanyName, c.Descr PrgName,a.DataNbr,b.docdate DocDate,b.totalcost,a.CrtDate ImgCrtDate,a.ID,
                                    CASE WHEN b.[Status] = 'Draft' THEN '草稿' ELSE '非草稿' END DocStatus  
                                    INTO #temp_Imageslist
                                    FROM CESImage.dbo.Images a
                                    INNER JOIN DocList b ON a.DataNbr = b.DataNbr
                                    INNER JOIN Programs c ON c.PrgID = b.PrgID
                                    INNER JOIN Company d ON d.CompanyCode = b.CompanyCode
                                    WHERE 1 = 1
                                    "); 
            if(!string.IsNullOrEmpty(CompanyCode))
            {
                sql += string.Format(@" AND b.CompanyCode = '{0}'", CompanyCode);
            }
            if (!string.IsNullOrEmpty(DateFm))
            {
                sql += string.Format(@" AND a.CrtDate >= '{0} 00:00:00'", DateFm);
            }
            if (!string.IsNullOrEmpty(DateTo))
            {
                sql += string.Format(@" AND a.CrtDate <= '{0} 23:59:59'", DateTo);
            }
            sql += " ;SELECT * FROM #temp_Imageslist ORDER BY ID";
            
            return curuow.ExecuteQuery<P_BM_DocImageDetail>(sql);
        }
    }
}
