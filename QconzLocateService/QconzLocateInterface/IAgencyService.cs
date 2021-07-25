using QconzLocateService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.QconzLocateInterface
{
    public interface IAgencyService
    {
        List<AgencyServiceModel> GetAllAgency(string Status);
        void SaveAgencyDetails(AgencyServiceModel AgencyModel);
        void SaveBulkAgencyDetails(List<AgencyServiceModel> AgencyModel);
        AgencyServiceModel GetAgencyDetails(Int64 Id);
    }
}

