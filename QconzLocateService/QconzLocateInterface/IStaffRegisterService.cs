using QconzLocateService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.QconzLocateInterface
{
    public interface IStaffRegisterService
    {
        List<StaffRegisterServiceModel> GetAllStaffRegister(string Status);
        void SaveStaffRegisterDetails(StaffRegisterServiceModel StaffRegisterModel);
        void SaveBulkStaffRegisterDetails(List<StaffRegisterServiceModel> StaffRegisterModel);
        StaffRegisterServiceModel GetStaffRegisterDetails(Int64 Id);
    }
}

