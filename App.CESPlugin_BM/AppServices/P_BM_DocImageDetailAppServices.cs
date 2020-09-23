using App.Plugin_BM.Specification;
using Da.CESPlugin_BM;
using Da.CESPlugin_BM.Repository;
using Da.Plugin_BM;
using Infrastructure;
using System.Collections.Generic;

namespace App.Plugin_BM.AppServices
{
    public class P_BM_DocImageDetailAppServices : APPServices<P_BM_DocImageDetail>
    {
        P_BM_DocImageDetailRepository curRepo;
        public P_BM_DocImageDetailAppServices()
        {
            var uow = new MainBCUnitOfWork();
            repository = curRepo = new P_BM_DocImageDetailRepository(uow);
            spec = new P_BM_DocImageDetailSpecification();
        }

        public List<P_BM_DocImageDetail> GetDocImageDetail(string CompanyCode,string DateFm, string DateTo)
        {
            return curRepo.GetDocImageDetail(CompanyCode,DateFm, DateTo);
        }

    }
}
