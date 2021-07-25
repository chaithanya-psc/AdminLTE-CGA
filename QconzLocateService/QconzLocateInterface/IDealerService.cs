using QconzLocateService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.QconzLocateInterface
{
    public interface IDealerService
    {
        List<DealerServiceModel> GetAllDealer(string Status);
        void SaveDealerDetails(DealerServiceModel DealerModel);
        void SaveBulkDealerDetails(List<DealerServiceModel> DealerModel);
        DealerServiceModel GetDealerDetails(Int64 Id);
    }
}

