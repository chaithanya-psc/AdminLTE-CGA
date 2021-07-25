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

    public class CylinderRegisterService : ICylinderRegisterService
    {
        private ICylinderRegisterRepository _ICylinderRegisterRepository = new CylinderRegisterRepository();
        //Get all companies
        public List<CylinderRegisterServiceModel> GetAllCylinderRegister(string Status)
        {
            try
            {
                var y = _ICylinderRegisterRepository.GetAllCylinderRegister(Status);
                return y.Select(c => new CylinderRegisterServiceModel
                {
                    Name = c.Name,
                    ShortName = c.ShortName,
                    HSN_Code = c.HSN_Code,
                    Remarks = c.Remarks,
                    RentDaysSlab1 = c.RentDaysSlab1,
                    RentDaysSlab2 = c.RentDaysSlab2,
                    SellingAmount = c.SellingAmount
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Get companies by Id

        public CylinderRegisterServiceModel GetCylinderRegisterDetails(Int64 Id)
        {
            try
            {
                var c = _ICylinderRegisterRepository.GetCylinderRegisterDetails(Id);
                return new CylinderRegisterServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ShortName = c.ShortName,
                    HSN_Code = c.HSN_Code,
                    Remarks = c.Remarks,
                    RentDaysSlab1 = c.RentDaysSlab1,
                    RentDaysSlab2 = c.RentDaysSlab2,
                    SellingAmount = c.SellingAmount
                };
            }
            catch
            {
                return null;
            }
        }

        public void SaveCylinderRegisterDetails(CylinderRegisterServiceModel CylinderRegisterDetails)
        {

            var CylinderRegister = new CylinderRegisterModel()
            {
                Id = CylinderRegisterDetails.Id,
                Name = CylinderRegisterDetails.Name,
                ShortName = CylinderRegisterDetails.ShortName,
                HSN_Code = CylinderRegisterDetails.HSN_Code,
                Remarks = CylinderRegisterDetails.Remarks,
                RentDaysSlab1 = CylinderRegisterDetails.RentDaysSlab1,
                RentDaysSlab2 = CylinderRegisterDetails.RentDaysSlab2,
                SellingAmount = CylinderRegisterDetails.SellingAmount
            };
            _ICylinderRegisterRepository.SaveCylinderRegisterDetails(CylinderRegister);
        }

        public void SaveBulkCylinderRegisterDetails(List<CylinderRegisterServiceModel> CylinderRegisterDetails)
        {

            var CylinderRegister = CylinderRegisterDetails.Select(c => new CylinderRegisterModel()
            {
                Id = c.Id,
                Name = c.Name,
                ShortName = c.ShortName,
                HSN_Code = c.HSN_Code,
                Remarks = c.Remarks,
                RentDaysSlab1 = c.RentDaysSlab1,
                RentDaysSlab2 = c.RentDaysSlab2,
                SellingAmount = c.SellingAmount
            }).ToList();
            _ICylinderRegisterRepository.SaveBulkCylinderRegisterDetails(CylinderRegister);
        }
    }
}
