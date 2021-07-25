using QconzLocateService.QconzLocateInterface;
using QconzLocateService.QconzLocateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QconzLocate.Models;
using QconzLocateService.Models;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace QconzLocate.Controllers
{
    //public class AgencyController : Controller
    //{
    //    // GET: Agency
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [SessionExpireFilter]
    [Authorize(Roles = "SUPER,ADMIN")]
    public class AgencyController : Controller
    {
        private IAgencyService _IAgencyService = new AgencyService();
        private CommonService _commonService = new CommonService();
        // GET: Agency list
        public ActionResult AgencyReport()
        {
          
            AgencyRegisterModel Agency = new AgencyRegisterModel();
            var Agencys = _IAgencyService.GetAllAgency( "A").Select(c => new AgencyListViewModel
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
            return View("AgencyList", Agencys);
        }

        //Get individual Agency
        public ActionResult AgencyRegister(Int64 id)
        {
           
            AgencyRegisterModel AgencyRegisterModel = new AgencyRegisterModel();
            AgencyListViewModel AgencyDetails;
            var c = _IAgencyService.GetAgencyDetails(id);
            if (id != 0)
            {
                AgencyDetails = new AgencyListViewModel
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
            else
            {
                AgencyDetails = new AgencyListViewModel
                {
                    Id = 0,
                    Name = null,
                    Address = null,
                    ShortName = null,
                    Mob1 = null,
                    Mob2 = null,
                    GST_Num = null,
                    Remarks = null,
                    M_Licence1 = null,
                    M_Licence2 = null,
                    D_Licence = null,
                    E_Licence = null,
                    Email = null,
                    Shop_Dealer = "SH"
                };
            }
            AgencyRegisterModel.AgencyDetails = AgencyDetails;

         
            return View("AgencyRegister", AgencyRegisterModel);
        }

        [HttpPost]
        public JsonResult SaveDetails(AgencyListViewModel Agency)
        {
            AgencyServiceModel AgencyModel;
            AgencyModel = new AgencyServiceModel()
            {
                Id = Agency.Id,
                Name = Agency.Name,
                Address = Agency.Address,
                ShortName = Agency.ShortName,
                Mob1 = Agency.Mob1,
                Mob2 = Agency.Mob2,
                GST_Num = Agency.GST_Num,
                Remarks = Agency.Remarks,
                M_Licence1 = Agency.M_Licence1,
                M_Licence2 = Agency.M_Licence2,
                D_Licence = Agency.D_Licence,
                E_Licence = Agency.E_Licence,
                Email = Agency.Email,
                Shop_Dealer = Agency.Shop_Dealer
            };
            _IAgencyService.SaveAgencyDetails(AgencyModel);
            bool success = true;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Download excel template
        public FileResult DownloadExcel()
        {
            string path = "~/Doc/Agency.xlsx";
            return File(path, "application/vnd.ms-excel", "Agency.xlsx");
        }

        //Process the uploaded excel file
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            
            if (upload != null && upload.ContentLength > 0)
            {

                Stream stream = upload.InputStream;
                IExcelDataReader reader = null;
                if (upload.FileName.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (upload.FileName.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else
                {
                    ModelState.AddModelError("File", "This file format is not supported");
                    return null;
                }
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                reader.Close();

                var AgencyBulk = result.Tables[0].Rows.Cast<DataRow>().Select(r => new AgencyServiceModel
                {

                    Address = r["Address"].ToString(),
                    Name = r["Name"].ToString(),
                    ShortName = r["ShortName"].ToString(),
                    GST_Num = r["GST_Num"].ToString(),
                    Mob1 = r["Mob1"].ToString(),
                    Mob2 = r["Mob2"].ToString(),
                    M_Licence1 = r["M_Licence1"].ToString(),
                    D_Licence = r["D_Licence"].ToString(),
                    E_Licence = r["E_Licence"].ToString(),
                    Email = r["Email"].ToString(),
                    Shop_Dealer = r["Shop_Dealer"].ToString(),
                    Remarks = "SH"
                }).ToList();
                _IAgencyService.SaveBulkAgencyDetails(AgencyBulk);

            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }


            AgencyRegisterModel Agency = new AgencyRegisterModel();
            var Agencys = _IAgencyService.GetAllAgency( "A").Select(c => new AgencyListViewModel
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
            return View("Agency", Agencys);
        }

        [HttpPost]
        public JsonResult GetAgencyReport(string Status)
        {
           
            var AgencyDetails = _IAgencyService.GetAllAgency( Status);
            return Json(AgencyDetails, JsonRequestBehavior.AllowGet);
        }
    }
}