using BM_Scheduler.Handle;
using Quartz;
using System;
using System.Diagnostics;

namespace BM_Scheduler.Scheduler
{
    public class InvJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                this.UpdateInvAll();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("商品档案对接发生异常:" + ex.Message);
            }
        }

        public void UpdateInvAll()
        {
            Trace.WriteLine("商品档案对接开始执行...");
            //商品档案
            DateTime ts1 = Convert.ToDateTime(BaseHandle.getxmlvalue("NCInvbasdoc"));            
            NCInvbasdoc_Handle ncinvbasdoc_Handle = new NCInvbasdoc_Handle();
            for (int i = 0; i < 100; i++)
            {
                int invFlag = ncinvbasdoc_Handle.GetInvbasdoc(ts1, i * 50, 50);
                if (invFlag == 0)
                {
                    Trace.WriteLine("商品档案对接完成执行,正常结束...");
                    break;
                }
                if (invFlag < 0)
                {
                    Trace.WriteLine("商品档案对接异常...");
                    break;
                }
            }
            BaseHandle.setxmlvalue("NCInvbasdoc", "Bama_NCInvbasdoc");
            //计量单位
            DateTime ts2 = Convert.ToDateTime(BaseHandle.getxmlvalue("NCMeasdoc"));
            NCMeasdoc_Handle ncmeasdoc_Handle = new NCMeasdoc_Handle();
            for (int j = 0; j < 100; j++)
            {
                int invFlag = ncmeasdoc_Handle.GetNCTariffItem(ts2, j * 50, 50);                
                if (invFlag == 0)
                {
                    Trace.WriteLine("计量单位对接完成执行,正常结束...");
                    break;
                }
                if (invFlag < 0)
                {
                    Trace.WriteLine("计量单位对接异常...");
                    break;
                }
            }
            BaseHandle.setxmlvalue("NCMeasdoc", "Bama_NCMeasdoc");
            //商品价格
            DateTime ts3 = Convert.ToDateTime(BaseHandle.getxmlvalue("NCTariffItem"));
            NCTariffItem_Handle nctariffitem_Handle = new NCTariffItem_Handle();
            for (int k = 0; k < 100; k++)
            {
                int invFlag = nctariffitem_Handle.GetNCTariffItem(ts3, k * 50, 50);
                if (invFlag == 0)
                {
                    Trace.WriteLine("商品价格对接完成执行,正常结束...");
                    break;
                }
                if (invFlag < 0)
                {
                    Trace.WriteLine("商品价格对接异常...");
                    break;
                }
            }
            BaseHandle.setxmlvalue("NCTariffItem", "Bama_NCTariffItem");

            //更新商品档案
            Inventory_Handle inventory_Handle = new Inventory_Handle();
            inventory_Handle.UpdateInventory();
            Trace.WriteLine("商品档案更新完成...");
        }
    }
}