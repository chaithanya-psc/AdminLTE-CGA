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
                    Address = c.Address,
                    ShortName = c.ShortName,
                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,
                    GST_Num = c.GST_Num,
                    Remarks = c.Remarks,
                    M_Licence1 = c.M_Licence1,
                    M_Licence2 = c.M_Licence2,
                    D_Licence = c.D_Licence,
                    E_Licence = c.E_Licence,
                    Email = c.Email,
                    Shop_Dealer = c.Shop_Dealer
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
                    Address = c.Address,
                    ShortName = c.ShortName,
                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,
                    GST_Num = c.GST_Num,
                    Remarks = c.Remarks,
                    M_Licence1 = c.M_Licence1,
                    M_Licence2 = c.M_Licence2,
                    D_Licence = c.D_Licence,
                    E_Licence = c.E_Licence,
                    Email = c.Email,
                    Shop_Dealer = c.Shop_Dealer
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
                Address = StaffRegisterDetails.Address,
                ShortName = StaffRegisterDetails.ShortName,
                Mob1 = StaffRegisterDetails.Mob1,
                Mob2 = StaffRegisterDetails.Mob2,
                GST_Num = StaffRegisterDetails.GST_Num,
                Remarks = StaffRegisterDetails.Remarks,
                M_Licence1 = StaffRegisterDetails.M_Licence1,
                M_Licence2 = StaffRegisterDetails.M_Licence2,
                D_Licence = StaffRegisterDetails.D_Licence,
                E_Licence = StaffRegisterDetails.E_Licence,
                Email = StaffRegisterDetails.Email,
                Shop_Dealer = StaffRegisterDetails.Shop_Dealer
            };
            _IStaffRegisterRepository.SaveStaffRegisterDetails(StaffRegister);
        }

        public void SaveBulkStaffRegisterDetails(List<StaffRegisterServiceModel> StaffRegisterDetails)
        {

            var StaffRegister = StaffRegisterDetails.Select(c => new StaffRegisterModel()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                ShortName = c.ShortName,
                Mob1 = c.Mob1,
                Mob2 = c.Mob2,
                GST_Num = c.GST_Num,
                Remarks = c.Remarks,
                M_Licence1 = c.M_Licence1,
                M_Licence2 = c.M_Licence2,
                D_Licence = c.D_Licence,
                E_Licence = c.E_Licence,
                Email = c.Email,
                Shop_Dealer = c.Shop_Dealer
            }).ToList();
            _IStaffRegisterRepository.SaveBulkStaffRegisterDetails(StaffRegister);
        }
    }
}
