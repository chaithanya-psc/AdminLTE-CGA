using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryInterface
{
    public interface IDealerRepository
    {
        List<DealerModel> GetAllDealer(string Status);
        DealerModel GetDealerDetails(Int64 Id);
        void SaveDealerDetails(DealerModel DealerModel);
        void SaveBulkDealerDetails(List<DealerModel> DealerModel);
    }
}
