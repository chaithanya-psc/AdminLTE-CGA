using QconzLocateDAL.QConzRepositoryInterface;
using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepository
{

    public class StaffRegisterRepository : IStaffRegisterRepository
    {
        QCONZEntities entity = new QCONZEntities();

        public List<StaffRegisterModel> GetAllStaffRegister(string Status)
        {
            try
            {
                List<StaffRegisterModel> StaffRegisterList = new List<StaffRegisterModel>();
                var y = (from t in entity.TBL_SHOP_DEALER_REGISTER select t).ToList();
                StaffRegisterList = y.Select(c => new StaffRegisterModel
                {
                    Id = c.ID,
                    Name = c.NAME,
                    Address = c.ADDRESS,
                    ShortName = c.SHORT_NAME,
                    Mob1 = c.MOB1,
                    Mob2 = c.MOB2,
                    GST_Num = c.GST_NUM,
                    Remarks = c.REMARKS,
                    M_Licence1 = c.M_LICENCE_NUM1,
                    M_Licence2 = c.M_LICENCE_NUM2,
                    D_Licence = c.D_LICENCE_NUM,
                    E_Licence = c.E_LICENCE_NUM,
                    Email = c.EMAIL,
                    Shop_Dealer = c.SHOP_OR_DEALER
                }
                ).ToList();
                return StaffRegisterList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public StaffRegisterModel GetStaffRegisterDetails(Int64 Id)
        {
            try
            {
                var y = (from c in entity.TBL_SHOP_DEALER_REGISTER
                         where c.ID == Id
                         select new StaffRegisterModel
                         {
                             Id = c.ID,
                             Name = c.NAME,
                             Address = c.ADDRESS,
                             ShortName = c.SHORT_NAME,
                             Mob1 = c.MOB1,
                             Mob2 = c.MOB2,
                             GST_Num = c.GST_NUM,
                             Remarks = c.REMARKS,
                             M_Licence1 = c.M_LICENCE_NUM1,
                             M_Licence2 = c.M_LICENCE_NUM2,
                             D_Licence = c.D_LICENCE_NUM,
                             E_Licence = c.E_LICENCE_NUM,
                             Email = c.EMAIL,
                             Shop_Dealer = c.SHOP_OR_DEALER
                         }).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveStaffRegisterDetails(StaffRegisterModel c)
        {
            try
            {
                if (c.Id == 0)
                {
                    var StaffRegister = new TBL_SHOP_DEALER_REGISTER()
                    {
                        NAME = c.Name,
                        ADDRESS = c.Address,
                        SHORT_NAME = c.ShortName,
                        MOB1 = c.Mob1,
                        MOB2 = c.Mob2,
                        GST_NUM = c.GST_Num,
                        REMARKS = c.Remarks,
                        M_LICENCE_NUM1 = c.M_Licence1,
                        M_LICENCE_NUM2 = c.M_Licence2,
                        D_LICENCE_NUM = c.D_Licence,
                        E_LICENCE_NUM = c.E_Licence,
                        EMAIL = c.Email,
                        SHOP_OR_DEALER = "SH"
                    };
                    entity.TBL_SHOP_DEALER_REGISTER.Add(StaffRegister);
                }
                else
                {
                    var y = entity.TBL_SHOP_DEALER_REGISTER.FirstOrDefault(t => t.ID == c.Id);
                    y.NAME = c.Name;
                    y.ADDRESS = c.Address;
                    y.SHORT_NAME = c.ShortName;
                    y.MOB1 = c.Mob1;
                    y.MOB2 = c.Mob2;
                    y.GST_NUM = c.GST_Num;
                    y.REMARKS = c.Remarks;
                    y.M_LICENCE_NUM1 = c.M_Licence1;
                    y.M_LICENCE_NUM2 = c.M_Licence2;
                    y.D_LICENCE_NUM = c.D_Licence;
                    y.E_LICENCE_NUM = c.E_Licence;
                    y.EMAIL = c.Email;
                    y.SHOP_OR_DEALER = c.Shop_Dealer;
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveBulkStaffRegisterDetails(List<StaffRegisterModel> StaffRegisterModel)
        {
            try
            {
                var CompanyId = StaffRegisterModel.FirstOrDefault();
                var StaffRegisters = entity.TBL_SHOP_DEALER_REGISTER;
                foreach (var item in StaffRegisters)
                {
                    entity.TBL_SHOP_DEALER_REGISTER.Remove(item);
                }
                foreach (var c in StaffRegisterModel)
                {
                    var StaffRegister = new TBL_SHOP_DEALER_REGISTER()
                    {
                        NAME = c.Name,
                        ADDRESS = c.Address,
                        SHORT_NAME = c.ShortName,
                        MOB1 = c.Mob1,
                        MOB2 = c.Mob2,
                        GST_NUM = c.GST_Num,
                        REMARKS = c.Remarks,
                        M_LICENCE_NUM1 = c.M_Licence1,
                        M_LICENCE_NUM2 = c.M_Licence2,
                        D_LICENCE_NUM = c.D_Licence,
                        E_LICENCE_NUM = c.E_Licence,
                        EMAIL = c.Email,
                        SHOP_OR_DEALER = "SH"
                    };
                    entity.TBL_SHOP_DEALER_REGISTER.Add(StaffRegister);
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
