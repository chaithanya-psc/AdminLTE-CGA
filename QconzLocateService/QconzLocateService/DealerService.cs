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

    public class DealerService : IDealerService
    {
        private IDealerRepository _IDealerRepository = new DealerRepository();
        //Get all companies
        public List<DealerServiceModel> GetAllDealer(string Status)
        {
            try
            {
                var y = _IDealerRepository.GetAllDealer(Status);
                return y.Select(c => new DealerServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    ShortName = c.ShortName,
                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,
                    GST_Num = c.GST_Num,
                    Remarks = c.Remarks,
              
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

        public DealerServiceModel GetDealerDetails(Int64 Id)
        {
            try
            {
                var c = _IDealerRepository.GetDealerDetails(Id);
                return new DealerServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    ShortName = c.ShortName,
                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,
                    GST_Num = c.GST_Num,
                    Remarks = c.Remarks,
                 
                    Email = c.Email,
                    Shop_Dealer = c.Shop_Dealer
                };
            }
            catch
            {
                return null;
            }
        }

        public void SaveDealerDetails(DealerServiceModel DealerDetails)
        {

            var Dealer = new DealerModel()
            {
                Id = DealerDetails.Id,
                Name = DealerDetails.Name,
                Address = DealerDetails.Address,
                ShortName = DealerDetails.ShortName,
                Mob1 = DealerDetails.Mob1,
                Mob2 = DealerDetails.Mob2,
                GST_Num = DealerDetails.GST_Num,
                Remarks = DealerDetails.Remarks,
            
                Email = DealerDetails.Email,
                Shop_Dealer = DealerDetails.Shop_Dealer
            };
            _IDealerRepository.SaveDealerDetails(Dealer);
        }

        public void SaveBulkDealerDetails(List<DealerServiceModel> DealerDetails)
        {

            var Dealer = DealerDetails.Select(c => new DealerModel()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                ShortName = c.ShortName,
                Mob1 = c.Mob1,
                Mob2 = c.Mob2,
                GST_Num = c.GST_Num,
                Remarks = c.Remarks,
             
                Email = c.Email,
                Shop_Dealer = c.Shop_Dealer
            }).ToList();
            _IDealerRepository.SaveBulkDealerDetails(Dealer);
        }
    }
}
