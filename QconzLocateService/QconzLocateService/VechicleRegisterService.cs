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

    public class VechicleRegisterService : IVechicleRegisterService
    {
        private IVechicleRegisterRepository _IVechicleRegisterRepository = new VechicleRegisterRepository();
        //Get all companies
        public List<VechicleRegisterServiceModel> GetAllVechicleRegister(string Status)
        {
            try
            {
                var y = _IVechicleRegisterRepository.GetAllVechicleRegister(Status);
                return y.Select(c => new VechicleRegisterServiceModel
                {
                    Id = c.Id,
                    Number = c.Number,
                    InsuranceDate = c.InsuranceDate,
                    TestDate = c.TestDate,
                    RegisterDate = c.RegistratioDate,
                    PolutionDate = c.PolutionDate,
                    Remarks = c.Remarks
                   
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Get companies by Id

        public VechicleRegisterServiceModel GetVechicleRegisterDetails(Int64 Id)
        {
            try
            {
                var c = _IVechicleRegisterRepository.GetVechicleRegisterDetails(Id);
                return new VechicleRegisterServiceModel
                {
                    Id = c.Id,
                    Number = c.Number,
                    InsuranceDate = c.InsuranceDate,
                    TestDate = c.TestDate,
                    RegisterDate = c.RegistratioDate,
                    PolutionDate = c.PolutionDate,
                    Remarks = c.Remarks
                };
            }
            catch
            {
                return null;
            }
        }

        public void SaveVechicleRegisterDetails(VechicleRegisterServiceModel VechicleRegisterDetails)
        {

            var VechicleRegister = new VechicleRegisterModel()
            {
                Id = VechicleRegisterDetails.Id,
                Number = VechicleRegisterDetails.Number,
                InsuranceDate = VechicleRegisterDetails.InsuranceDate,
                TestDate = VechicleRegisterDetails.TestDate,
                RegistratioDate = VechicleRegisterDetails.RegisterDate,
                PolutionDate = VechicleRegisterDetails.PolutionDate,
                Remarks = VechicleRegisterDetails.Remarks
            };
            _IVechicleRegisterRepository.SaveVechicleRegisterDetails(VechicleRegister);
        }

        public void SaveBulkVechicleRegisterDetails(List<VechicleRegisterServiceModel> VechicleRegisterDetails)
        {

            var VechicleRegister = VechicleRegisterDetails.Select(c => new VechicleRegisterModel()
            {
                Id = c.Id,
                Number = c.Number,
                InsuranceDate = c.InsuranceDate,
                TestDate = c.TestDate,
                RegistratioDate = c.RegisterDate,
                PolutionDate = c.PolutionDate,
                Remarks = c.Remarks
            }).ToList();
            _IVechicleRegisterRepository.SaveBulkVechicleRegisterDetails(VechicleRegister);
        }
    }
}
