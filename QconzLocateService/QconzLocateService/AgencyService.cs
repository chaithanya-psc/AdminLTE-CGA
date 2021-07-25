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
    
    public class AgencyService : IAgencyService
    {
        private IAgencyRepository _IAgencyRepository = new AgencyRepository();
        //Get all companies
        public List<AgencyServiceModel> GetAllAgency(string Status)
        {
            try
            {
                var y = _IAgencyRepository.GetAllAgency(Status);
                return y.Select(c => new AgencyServiceModel
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

        public AgencyServiceModel GetAgencyDetails(Int64 Id)
        {
            try
            {
                var c = _IAgencyRepository.GetAgencyDetails(Id);
                return new AgencyServiceModel
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

        public void SaveAgencyDetails(AgencyServiceModel AgencyDetails)
        {

            var Agency = new AgencyModel()
            {
                Id = AgencyDetails.Id,
                Name = AgencyDetails.Name,
                Address = AgencyDetails.Address,
                ShortName = AgencyDetails.ShortName,
                Mob1 = AgencyDetails.Mob1,
                Mob2 = AgencyDetails.Mob2,
                GST_Num = AgencyDetails.GST_Num,
                Remarks = AgencyDetails.Remarks,
                M_Licence1 = AgencyDetails.M_Licence1,
                M_Licence2 = AgencyDetails.M_Licence2,
                D_Licence = AgencyDetails.D_Licence,
                E_Licence = AgencyDetails.E_Licence,
                Email = AgencyDetails.Email,
                Shop_Dealer = AgencyDetails.Shop_Dealer
            };
            _IAgencyRepository.SaveAgencyDetails(Agency);
        }

        public void SaveBulkAgencyDetails(List<AgencyServiceModel> AgencyDetails)
        {

            var Agency = AgencyDetails.Select(c => new AgencyModel()
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
            _IAgencyRepository.SaveBulkAgencyDetails(Agency);
        }
    }
}
