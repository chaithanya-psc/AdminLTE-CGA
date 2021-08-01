using QconzLocateDAL.QConzRepositoryInterface;
using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepository
{

    public class DealerRepository : IDealerRepository
    {
        QCONZEntities entity = new QCONZEntities();

        public List<DealerModel> GetAllDealer(string Status)
        {
            try
            {
                List<DealerModel> DealerList = new List<DealerModel>();
                var y = (from t in entity.TBL_SHOP_DEALER_REGISTER where (t.SHOP_OR_DEALER == "DL")select t).ToList();
                DealerList = y.Select(c => new DealerModel
                {
                    Id = c.ID,
                    Name = c.NAME,
                    Address = c.ADDRESS,
                    ShortName = c.SHORT_NAME,
                    Mob1 = c.MOB1,
                    Mob2 = c.MOB2,
                    GST_Num = c.GST_NUM,
                    Remarks = c.REMARKS,
                
                    Email = c.EMAIL,
                    Shop_Dealer = c.SHOP_OR_DEALER
                }
                ).ToList();
                return DealerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DealerModel GetDealerDetails(Int64 Id)
        {
            try
            {
                var y = (from c in entity.TBL_SHOP_DEALER_REGISTER
                         where c.ID == Id
                         select new DealerModel
                         {
                             Id = c.ID,
                             Name = c.NAME,
                             Address = c.ADDRESS,
                             ShortName = c.SHORT_NAME,
                             Mob1 = c.MOB1,
                             Mob2 = c.MOB2,
                             GST_Num = c.GST_NUM,
                             Remarks = c.REMARKS,
                            
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

        public void SaveDealerDetails(DealerModel c)
        {
            try
            {
                if (c.Id == 0)
                {
                    var Dealer = new TBL_SHOP_DEALER_REGISTER()
                    {
                        NAME = c.Name,
                        ADDRESS = c.Address,
                        SHORT_NAME = c.ShortName,
                        MOB1 = c.Mob1,
                        MOB2 = c.Mob2,
                        GST_NUM = c.GST_Num,
                        REMARKS = c.Remarks,
                     
                        EMAIL = c.Email,
                        SHOP_OR_DEALER = "DL",
                        CREATED_ON = DateTime.Now,
                        MODIFIED_ON = DateTime.Now
                    };
                    entity.TBL_SHOP_DEALER_REGISTER.Add(Dealer);
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
                 
                    y.EMAIL = c.Email;
                    y.SHOP_OR_DEALER = c.Shop_Dealer;


                    y.MODIFIED_ON = DateTime.Now;
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveBulkDealerDetails(List<DealerModel> DealerModel)
        {
            try
            {
                var CompanyId = DealerModel.FirstOrDefault();
                var Dealers = entity.TBL_SHOP_DEALER_REGISTER;
                foreach (var item in Dealers)
                {
                    entity.TBL_SHOP_DEALER_REGISTER.Remove(item);
                }
                foreach (var c in DealerModel)
                {
                    var Dealer = new TBL_SHOP_DEALER_REGISTER()
                    {
                        NAME = c.Name,
                        ADDRESS = c.Address,
                        SHORT_NAME = c.ShortName,
                        MOB1 = c.Mob1,
                        MOB2 = c.Mob2,
                        GST_NUM = c.GST_Num,
                        REMARKS = c.Remarks,
                
                        EMAIL = c.Email,
                        SHOP_OR_DEALER = "DL"
                    };
                    entity.TBL_SHOP_DEALER_REGISTER.Add(Dealer);
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
