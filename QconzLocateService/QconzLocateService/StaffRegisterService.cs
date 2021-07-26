using QconzLocateDAL.QConzRepository;
using QconzLocateDAL.QConzRepositoryInterface;
using QconzLocateDAL.QConzRepositoryModel;
using QconzLocateService.Models;
using QconzLocateService.QconzLocateInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.QconzLocateService
{

    public class StaffRegisterService : IStaffRegisterService
    {
        private IStaffRegisterRepository _IStaffRegisterRepository = new StaffRegisterRepository();
        //Get all companies
        public List<StaffRegisterServiceModel> GetAllStaffRegister(string Status)
        {
            try
            {
                var y = _IStaffRegisterRepository.GetAllStaffRegister(Status);
                return y.Select(c => new StaffRegisterServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Adrees = c.Adrees,

                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,

                    Remarks = c.Remarks,
                    JoinDate = c.JoinDate
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Get companies by Id

        public StaffRegisterServiceModel GetStaffRegisterDetails(Int64 Id)
        {
            try
            {
                var c = _IStaffRegisterRepository.GetStaffRegisterDetails(Id);
                return new StaffRegisterServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Adrees = c.Adrees,

                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,

                    Remarks = c.Remarks,
                    JoinDate = c.JoinDate
                };
            }
            catch
            {
                return null;
            }
        }

        public void SaveStaffRegisterDetails(StaffRegisterServiceModel StaffRegisterDetails)
        {

            var StaffRegister = new StaffRegisterModel()
            {
                Id = StaffRegisterDetails.Id,
                Name = StaffRegisterDetails.Name,
                Adrees = StaffRegisterDetails.Adrees,

                Mob1 = StaffRegisterDetails.Mob1,
                Mob2 = StaffRegisterDetails.Mob2,

                Remarks = StaffRegisterDetails.Remarks,
                JoinDate = StaffRegisterDetails.JoinDate
            };
            _IStaffRegisterRepository.SaveStaffRegisterDetails(StaffRegister);
        }

        public void SaveBulkStaffRegisterDetails(List<StaffRegisterServiceModel> StaffRegisterDetails)
        {

            var StaffRegister = StaffRegisterDetails.Select(c => new StaffRegisterModel()
            {
                Id = c.Id,
                Name = c.Name,
                Adrees = c.Adrees,

                Mob1 = c.Mob1,
                Mob2 = c.Mob2,

                Remarks = c.Remarks,
                JoinDate = c.JoinDate
            }).ToList();
            _IStaffRegisterRepository.SaveBulkStaffRegisterDetails(StaffRegister);
        }
    }
}
