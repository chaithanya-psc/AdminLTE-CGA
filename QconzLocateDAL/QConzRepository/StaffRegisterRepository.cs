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
                var y = (from t in entity.TBL_STAFF_REGISTER select t).ToList();
                StaffRegisterList = y.Select(c => new StaffRegisterModel
                {
                    Id = c.ID,
                    Name = c.NAME,
                    Adrees = c.ADDRESS,
                   
                    Mob1 = c.MOB1,
                    Mob2 = c.MOB2,
                   
                    Remarks = c.REMARKS,
                    JoinDate = c.JOIN_DATE
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
                var y = (from c in entity.TBL_STAFF_REGISTER
                         where c.ID == Id
                         select new StaffRegisterModel
                         {
                             Id = c.ID,
                             Name = c.NAME,
                             Adrees = c.ADDRESS,

                             Mob1 = c.MOB1,
                             Mob2 = c.MOB2,

                             Remarks = c.REMARKS,
                             JoinDate = c.JOIN_DATE
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
                    var StaffRegister = new TBL_STAFF_REGISTER()
                    {
                        NAME = c.Name,
                        ADDRESS = c.Adrees,
                        MOB1 = c.Mob1,
                        MOB2 = c.Mob2,
                        REMARKS = c.Remarks,
                        JOIN_DATE = c.JoinDate,
                        CREATED_ON=DateTime.Now,
                        MODIFIED_ON=DateTime.Now
                    };
                    entity.TBL_STAFF_REGISTER.Add(StaffRegister);
                }
                else
                {
                    var y = entity.TBL_STAFF_REGISTER.FirstOrDefault(t => t.ID == c.Id);
                    y.NAME = c.Name;
                    y.ADDRESS = c.Adrees;
                    y.MOB1 = c.Mob1;
                    y.MOB2 = c.Mob2;
                    y.REMARKS = c.Remarks;
                    y.JOIN_DATE = c.JoinDate;
                   
                    y.MODIFIED_ON = DateTime.Now;
                   
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
                var StaffRegisters = entity.TBL_STAFF_REGISTER;
                foreach (var item in StaffRegisters)
                {
                    entity.TBL_STAFF_REGISTER.Remove(item);
                }
                foreach (var c in StaffRegisterModel)
                {
                    var StaffRegister = new TBL_STAFF_REGISTER()
                    {
                        NAME = c.Name,
                        ADDRESS = c.Adrees,
                        MOB1 = c.Mob1,
                        MOB2 = c.Mob2,
                        REMARKS = c.Remarks,
                        JOIN_DATE = c.JoinDate,
                        CREATED_ON = DateTime.Now,
                        MODIFIED_ON = DateTime.Now
                    };
                    entity.TBL_STAFF_REGISTER.Add(StaffRegister);
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
