using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryInterface
{
    public interface ICylinderRegisterRepository
    {
        List<CylinderRegisterModel> GetAllCylinderRegister(string Status);
        CylinderRegisterModel GetCylinderRegisterDetails(Int64 Id);
        void SaveCylinderRegisterDetails(CylinderRegisterModel CylinderRegisterModel);
        void SaveBulkCylinderRegisterDetails(List<CylinderRegisterModel> CylinderRegisterModel);
    }
}
