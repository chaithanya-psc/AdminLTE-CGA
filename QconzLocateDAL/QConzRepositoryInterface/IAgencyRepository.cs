using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryInterface
{
    public interface IAgencyRepository
    {
        List<AgencyModel> GetAllAgency(string Status);
        AgencyModel GetAgencyDetails(Int64 Id);
        void SaveAgencyDetails(AgencyModel AgencyModel);
        void SaveBulkAgencyDetails(List<AgencyModel> AgencyModel);
    }
}
