using QconzLocateDAL.QConzRepositoryInterface;
using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepository
{

    public class VechicleRegisterRepository : IVechicleRegisterRepository
    {
        QCONZEntities entity = new QCONZEntities();

        public List<VechicleRegisterModel> GetAllVechicleRegister(string Status)
        {
            try
            {
                List<VechicleRegisterModel> VechicleRegisterList = new List<VechicleRegisterModel>();
                var y = (from t in entity.TBL_VECHICLE_REGISTER select t).ToList();
                VechicleRegisterList = y.Select(c => new VechicleRegisterModel
                {
                    Id = c.ID,
                    Number = c.NUMBER,
                    InsuranceDate = c.INSURANCE_DATE,
                    TestDate = c.TEST_DATE,
                    RegistratioDate = c.PURCHASE_DATE,
                    PolutionDate = c.POLUTION_DATE,
                    Remarks = c.REMARKS
                }
                ).ToList();
                return VechicleRegisterList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public VechicleRegisterModel GetVechicleRegisterDetails(Int64 Id)
        {
            try
            {
                var y = (from c in entity.TBL_VECHICLE_REGISTER
                         where c.ID == Id
                         select new VechicleRegisterModel
                         {
                             Id = c.ID,
                             Number = c.NUMBER,
                             InsuranceDate = c.INSURANCE_DATE,
                             TestDate = c.TEST_DATE,
                             RegistratioDate = c.PURCHASE_DATE,
                             PolutionDate = c.POLUTION_DATE,
                             Remarks = c.REMARKS
                         }).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveVechicleRegisterDetails(VechicleRegisterModel c)
        {
            try
            {
                if (c.Id == 0)
                {
                    var VechicleRegister = new TBL_VECHICLE_REGISTER()
                    {
                        NUMBER = c.Number,
                        INSURANCE_DATE = c.InsuranceDate,
                        TEST_DATE = c.TestDate,
                        PURCHASE_DATE = c.RegistratioDate,
                        POLUTION_DATE = c.PolutionDate,
                        REMARKS = c.Remarks
                    };
                    entity.TBL_VECHICLE_REGISTER.Add(VechicleRegister);
                }
                else
                {
                    var y = entity.TBL_VECHICLE_REGISTER.FirstOrDefault(t => t.ID == c.Id);
                    y.NUMBER = c.Number;
                    y.INSURANCE_DATE = c.InsuranceDate;
                    y.TEST_DATE = c.TestDate;
                    y.PURCHASE_DATE = c.RegistratioDate;
                    y.POLUTION_DATE = c.PolutionDate;
                    y.REMARKS = c.Remarks; 
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveBulkVechicleRegisterDetails(List<VechicleRegisterModel> VechicleRegisterModel)
        {
            try
            {
                var CompanyId = VechicleRegisterModel.FirstOrDefault();
                var VechicleRegisters = entity.TBL_SHOP_DEALER_REGISTER;
                foreach (var item in VechicleRegisters)
                {
                    entity.TBL_SHOP_DEALER_REGISTER.Remove(item);
                }
                foreach (var c in VechicleRegisterModel)
                {
                    var VechicleRegister = new TBL_VECHICLE_REGISTER()
                    {
                        NUMBER = c.Number,
                        INSURANCE_DATE = c.InsuranceDate,
                        TEST_DATE = c.TestDate,
                        PURCHASE_DATE = c.RegistratioDate,
                        POLUTION_DATE = c.PolutionDate,
                        REMARKS = c.Remarks
                    };
                    entity.TBL_VECHICLE_REGISTER.Add(VechicleRegister);
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
