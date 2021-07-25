using QconzLocateDAL.QConzRepositoryInterface;
using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepository
{

    public class CylinderRegisterRepository : ICylinderRegisterRepository
    {
        QCONZEntities entity = new QCONZEntities();

        public List<CylinderRegisterModel> GetAllCylinderRegister(string Status)
        {
            try
            {
                List<CylinderRegisterModel> CylinderRegisterList = new List<CylinderRegisterModel>();
                var y = (from t in entity.TBL_CYLINDER_MASTER select t).ToList();
                CylinderRegisterList = y.Select(c => new CylinderRegisterModel
                {
                    Id = c.ID,
                    Name = c.NAME,
                    ShortName = c.CYLINDER_SHORT_NAME,
                    HSN_Code = c.HSN_CODE,
                    Remarks = c.REMARKS,
                    RentDaysSlab1 = c.RENT_DAYS_SLAB1,
                    RentDaysSlab2 = c.RENT_DAYS_SLAB2,
                    SellingAmount = c.SELLING_AMOUNT
                }
                ).ToList();
                return CylinderRegisterList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CylinderRegisterModel GetCylinderRegisterDetails(Int64 Id)
        {
            try
            {
                var y = (from c in entity.TBL_CYLINDER_MASTER
                         where c.ID == Id
                         select new CylinderRegisterModel
                         {
                             Id = c.ID,
                             Name = c.NAME,
                             ShortName = c.CYLINDER_SHORT_NAME,
                             HSN_Code = c.HSN_CODE,
                             Remarks = c.REMARKS,
                             RentDaysSlab1 = c.RENT_DAYS_SLAB1,
                             RentDaysSlab2 = c.RENT_DAYS_SLAB2,
                             SellingAmount = c.SELLING_AMOUNT
                         }).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveCylinderRegisterDetails(CylinderRegisterModel c)
        {
            try
            {
                if (c.Id == 0)
                {
                    var CylinderRegister = new TBL_CYLINDER_MASTER()
                    {
                        NAME = c.Name,
                        CYLINDER_SHORT_NAME = c.ShortName,
                        HSN_CODE = c.HSN_Code,
                        REMARKS = c.Remarks,
                        RENT_DAYS_SLAB1 = c.RentDaysSlab1,
                        RENT_DAYS_SLAB2 = c.RentDaysSlab2,
                        SELLING_AMOUNT = c.SellingAmount
                    };
                    entity.TBL_CYLINDER_MASTER.Add(CylinderRegister);
                }
                else
                {
                    var y = entity.TBL_CYLINDER_MASTER.FirstOrDefault(t => t.ID == c.Id);
                    y.NAME = c.Name;
                    y.CYLINDER_SHORT_NAME = c.ShortName;
                    y.HSN_CODE = c.HSN_Code;
                    y.REMARKS = c.Remarks;
                    y.RENT_DAYS_SLAB1 = c.RentDaysSlab1;
                    y.RENT_DAYS_SLAB2 = c.RentDaysSlab2;
                    y.SELLING_AMOUNT = c.SellingAmount;
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveBulkCylinderRegisterDetails(List<CylinderRegisterModel> CylinderRegisterModel)
        {
            try
            {
                var CompanyId = CylinderRegisterModel.FirstOrDefault();
                var CylinderRegisters = entity.TBL_SHOP_DEALER_REGISTER;
                foreach (var item in CylinderRegisters)
                {
                    entity.TBL_SHOP_DEALER_REGISTER.Remove(item);
                }
                foreach (var c in CylinderRegisterModel)
                {
                    var CylinderRegister = new TBL_CYLINDER_MASTER()
                    {
                        NAME = c.Name,
                        CYLINDER_SHORT_NAME = c.ShortName,
                        HSN_CODE = c.HSN_Code,
                        REMARKS = c.Remarks,
                        RENT_DAYS_SLAB1 = c.RentDaysSlab1,
                        RENT_DAYS_SLAB2 = c.RentDaysSlab2,
                        SELLING_AMOUNT = c.SellingAmount
                    };
                    entity.TBL_CYLINDER_MASTER.Add(CylinderRegister);
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
