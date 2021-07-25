using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryInterface
{
    public interface IStaffRegisterRepository
    {
        List<StaffRegisterModel> GetAllStaffRegister(string Status);
        StaffRegisterModel GetStaffRegisterDetails(Int64 Id);
        void SaveStaffRegisterDetails(StaffRegisterModel StaffRegisterModel);
        void SaveBulkStaffRegisterDetails(List<StaffRegisterModel> StaffRegisterModel);
    }
}
