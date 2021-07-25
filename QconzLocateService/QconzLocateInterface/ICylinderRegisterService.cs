using QconzLocateService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.QconzLocateInterface
{
    public interface ICylinderRegisterService
    {
        List<CylinderRegisterServiceModel> GetAllCylinderRegister(string Status);
        void SaveCylinderRegisterDetails(CylinderRegisterServiceModel CylinderRegisterModel);
        void SaveBulkCylinderRegisterDetails(List<CylinderRegisterServiceModel> CylinderRegisterModel);
        CylinderRegisterServiceModel GetCylinderRegisterDetails(Int64 Id);
    }
}

