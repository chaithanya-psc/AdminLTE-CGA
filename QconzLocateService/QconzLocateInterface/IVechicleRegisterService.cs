using QconzLocateService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.QconzLocateInterface
{
    public interface IVechicleRegisterService
    {
        List<VechicleRegisterServiceModel> GetAllVechicleRegister(string Status);
        void SaveVechicleRegisterDetails(VechicleRegisterServiceModel VechicleRegisterModel);
        void SaveBulkVechicleRegisterDetails(List<VechicleRegisterServiceModel> VechicleRegisterModel);
        VechicleRegisterServiceModel GetVechicleRegisterDetails(Int64 Id);
    }
}

