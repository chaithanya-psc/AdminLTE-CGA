using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryInterface
{
    public interface IVechicleRegisterRepository
    {
        List<VechicleRegisterModel> GetAllVechicleRegister(string Status);
        VechicleRegisterModel GetVechicleRegisterDetails(Int64 Id);
        void SaveVechicleRegisterDetails(VechicleRegisterModel VechicleRegisterModel);
        void SaveBulkVechicleRegisterDetails(List<VechicleRegisterModel> VechicleRegisterModel);
    }
}
