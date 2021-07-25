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

    //public class OwnCylinderRegisterService : IOwnCylinderRegisterService
    //{
    //    private IOwnCylinderRegisterRepository _IOwnCylinderRegisterRepository = new OwnCylinderRegisterRepository();
    //    //Get all companies
    //    public List<OwnCylinderRegisterServiceModel> GetAllOwnCylinderRegister(string Status)
    //    {
    //        try
    //        {
    //            var y = _IOwnCylinderRegisterRepository.GetAllOwnCylinderRegister(Status);
    //            return y.Select(c => new OwnCylinderRegisterServiceModel
    //            {
    //                Id = c.Id,
    //                Name = c.Name,
    //                Address = c.Address,
    //                ShortName = c.ShortName,
    //                Mob1 = c.Mob1,
    //                Mob2 = c.Mob2,
    //                GST_Num = c.GST_Num,
    //                Remarks = c.Remarks,
    //                M_Licence1 = c.M_Licence1,
    //                M_Licence2 = c.M_Licence2,
    //                D_Licence = c.D_Licence,
    //                E_Licence = c.E_Licence,
    //                Email = c.Email,
    //                Shop_Dealer = c.Shop_Dealer
    //            }).ToList();
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    //Get companies by Id

    //    public OwnCylinderRegisterServiceModel GetOwnCylinderRegisterDetails(Int64 Id)
    //    {
    //        try
    //        {
    //            var c = _IOwnCylinderRegisterRepository.GetOwnCylinderRegisterDetails(Id);
    //            return new OwnCylinderRegisterServiceModel
    //            {
    //                Id = c.Id,
    //                Name = c.Name,
    //                Address = c.Address,
    //                ShortName = c.ShortName,
    //                Mob1 = c.Mob1,
    //                Mob2 = c.Mob2,
    //                GST_Num = c.GST_Num,
    //                Remarks = c.Remarks,
    //                M_Licence1 = c.M_Licence1,
    //                M_Licence2 = c.M_Licence2,
    //                D_Licence = c.D_Licence,
    //                E_Licence = c.E_Licence,
    //                Email = c.Email,
    //                Shop_Dealer = c.Shop_Dealer
    //            };
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }

    //    public void SaveOwnCylinderRegisterDetails(OwnCylinderRegisterServiceModel OwnCylinderRegisterDetails)
    //    {

    //        var OwnCylinderRegister = new OwnCylinderRegisterModel()
    //        {
    //            Id = OwnCylinderRegisterDetails.Id,
    //            Name = OwnCylinderRegisterDetails.Name,
    //            Address = OwnCylinderRegisterDetails.Address,
    //            ShortName = OwnCylinderRegisterDetails.ShortName,
    //            Mob1 = OwnCylinderRegisterDetails.Mob1,
    //            Mob2 = OwnCylinderRegisterDetails.Mob2,
    //            GST_Num = OwnCylinderRegisterDetails.GST_Num,
    //            Remarks = OwnCylinderRegisterDetails.Remarks,
    //            M_Licence1 = OwnCylinderRegisterDetails.M_Licence1,
    //            M_Licence2 = OwnCylinderRegisterDetails.M_Licence2,
    //            D_Licence = OwnCylinderRegisterDetails.D_Licence,
    //            E_Licence = OwnCylinderRegisterDetails.E_Licence,
    //            Email = OwnCylinderRegisterDetails.Email,
    //            Shop_Dealer = OwnCylinderRegisterDetails.Shop_Dealer
    //        };
    //        _IOwnCylinderRegisterRepository.SaveOwnCylinderRegisterDetails(OwnCylinderRegister);
    //    }

    //    public void SaveBulkOwnCylinderRegisterDetails(List<OwnCylinderRegisterServiceModel> OwnCylinderRegisterDetails)
    //    {

    //        var OwnCylinderRegister = OwnCylinderRegisterDetails.Select(c => new OwnCylinderRegisterModel()
    //        {
    //            Id = c.Id,
    //            Name = c.Name,
    //            Address = c.Address,
    //            ShortName = c.ShortName,
    //            Mob1 = c.Mob1,
    //            Mob2 = c.Mob2,
    //            GST_Num = c.GST_Num,
    //            Remarks = c.Remarks,
    //            M_Licence1 = c.M_Licence1,
    //            M_Licence2 = c.M_Licence2,
    //            D_Licence = c.D_Licence,
    //            E_Licence = c.E_Licence,
    //            Email = c.Email,
    //            Shop_Dealer = c.Shop_Dealer
    //        }).ToList();
    //        _IOwnCylinderRegisterRepository.SaveBulkOwnCylinderRegisterDetails(OwnCylinderRegister);
    //    }
    //}
}
