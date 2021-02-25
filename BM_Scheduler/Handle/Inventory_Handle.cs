using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BM_Scheduler.Handle
{
    public class Inventory_Handle : BaseHandle
    {
        /// <summary>
        /// 更新商品档案
        /// </summary>
        public void UpdateInventory()
        {
            string sql = @"SELECT a.invcode, a.invname,b.measname,c.nprice1,a.pk_invmandoc,a.pk_measdoc
                             FROM Bama_NCInvbasdoc a
                            INNER JOIN Bama_NCMeasdoc b ON b.pk_measdoc =  a.pk_measdoc
                            LEFT  JOIN Bama_NCTariffItem c ON c.cinventoryid =  a.pk_invmandoc
                            WHERE a.iState = 0 OR c.iState = 0 OR b.iState = 0";
            var ds = SqlHelper.ExecuteDataset(CommandType.Text, sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql1 = @"IF NOT EXISTS (SELECT 1 FROM P_Inventory WHERE InvCode = @InvCode)
                                INSERT INTO P_Inventory(CompanyCode, InvCode, InvName, Unit, UnitPrice, EffDate,
                                CrtUser, CrtDate, UpdateUser, UpdateDT, [Status], Remark, CrtUserName,
                                UpdateUserName, AccCompany)
                                VALUES(@CompanyCode, @InvCode, @InvName, @Unit, @UnitPrice, @EffDate,
                                @CrtUser, @CrtDate, @UpdateUser, @UpdateDT, @Status, @Remark, @CrtUserName,
                                @UpdateUserName, @AccCompany)
                                ELSE UPDATE P_Inventory SET InvName = @InvName,UnitPrice=@UnitPrice ,UpdateDT=@UpdateDT
                                WHERE InvCode = @InvCode;
                                UPDATE Bama_NCInvbasdoc SET iState = @iState,DModify = @DModify WHERE pk_invmandoc = @pk_invmandoc;
                                UPDATE Bama_NCMeasdoc SET iState = @iState,DModify = @DModify WHERE pk_measdoc = @pk_measdoc;
                                UPDATE Bama_NCTariffItem SET iState = @iState,DModify = @DModify WHERE cinventoryid = @pk_invmandoc;";
                var dataList = ds.Tables.Cast<DataTable>().ToList();
                for (int i = 0; i <= dataList.Count; i++)
                {
                    SqlParameter[] paras =
                    {
                        new SqlParameter("@CompanyCode","1101"),
                        new SqlParameter("@InvCode",dataList[i].Columns["invcode"].ToString()),
                        new SqlParameter("@InvName",dataList[i].Columns["invname"].ToString()),
                        new SqlParameter("@Unit",dataList[i].Columns["measname"].ToString()),
                        new SqlParameter("@UnitPrice",dataList[i].Columns["nprice1"].ToString()),
                        new SqlParameter("@EffDate",DateTime.Now),
                        new SqlParameter("@CrtUser","admin"),
                        new SqlParameter("@CrtDate",DateTime.Now),
                        new SqlParameter("@UpdateUser","admin"),
                        new SqlParameter("@UpdateDT",DateTime.Now),
                        new SqlParameter("@Status","Approval"),
                        new SqlParameter("@Remark",""),
                        new SqlParameter("@CrtUserName","管理员"),
                        new SqlParameter("@UpdateUserName","管理员"),
                        new SqlParameter("@AccCompany","1101"),
                        new SqlParameter("@pk_invmandoc",dataList[i].Columns["pk_invmandoc"].ToString()),
                        new SqlParameter("@pk_measdoc",dataList[i].Columns["pk_measdoc"].ToString()),                        
                     };
                    SqlHelper.ExecuteNonQuery(CommandType.Text, sql1, paras);
                }
            }
        }
    }
}