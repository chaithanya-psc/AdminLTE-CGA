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
    //public class DealerController : Controller
    //{
    //    // GET: Dealer
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [SessionExpireFilter]
    [Authorize(Roles = "SUPER,ADMIN")]
    public class DealerController : Controller
    {
        private IDealerService _IDealerService = new DealerService();
        private CommonService _commonService = new CommonService();
        // GET: Dealer list
        public ActionResult DealerReport()
        {

            DealerRegisterModel Dealer = new DealerRegisterModel();
            var Dealers = _IDealerService.GetAllDealer("A").Select(c => new DealerListViewModel
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
            return View("DealerList", Dealers);
        }

        //Get individual Dealer
        public ActionResult DealerRegister(Int64 id)
        {

            DealerRegisterModel DealerRegisterModel = new DealerRegisterModel();
            DealerListViewModel DealerDetails;
            var c = _IDealerService.GetDealerDetails(id);
            if (id != 0)
            {
                DealerDetails = new DealerListViewModel
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
            else
            {
                DealerDetails = new DealerListViewModel
                {
                    Id = 0,
                    Name = null,
                    Address = null,
                    ShortName = null,
                    Mob1 = null,
                    Mob2 = null,
                    GST_Num = null,
                    Remarks = null,
              
                    Email = null,
                    Shop_Dealer = "DL"
                };
            }
            DealerRegisterModel.DealerDetails = DealerDetails;


            return View("DealerRegister", DealerRegisterModel);
        }

        [HttpPost]
        public JsonResult SaveDetails(DealerListViewModel Dealer)
        {
            DealerServiceModel DealerModel;
            DealerModel = new DealerServiceModel()
            {
                Id = Dealer.Id,
                Name = Dealer.Name,
                Address = Dealer.Address,
                ShortName = Dealer.ShortName,
                Mob1 = Dealer.Mob1,
                Mob2 = Dealer.Mob2,
                GST_Num = Dealer.GST_Num,
                Remarks = Dealer.Remarks,
          
                Email = Dealer.Email,
                Shop_Dealer = Dealer.Shop_Dealer
            };
            _IDealerService.SaveDealerDetails(DealerModel);
            bool success = true;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Download excel template
        public FileResult DownloadExcel()
        {
            string path = "~/Doc/Dealer.xlsx";
            return File(path, "application/vnd.ms-excel", "Dealer.xlsx");
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

                var DealerBulk = result.Tables[0].Rows.Cast<DataRow>().Select(r => new DealerServiceModel
                {

                    Address = r["Address"].ToString(),
                    Name = r["Name"].ToString(),
                    ShortName = r["ShortName"].ToString(),
                    GST_Num = r["GST_Num"].ToString(),
                    Mob1 = r["Mob1"].ToString(),
                    Mob2 = r["Mob2"].ToString(),
                  
                    Email = r["Email"].ToString(),
                    Shop_Dealer = "DL",
                    Remarks = r["Remarks"].ToString(),
                }).ToList();
                _IDealerService.SaveBulkDealerDetails(DealerBulk);

            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }


            DealerRegisterModel Dealer = new DealerRegisterModel();
            var Dealers = _IDealerService.GetAllDealer("A").Select(c => new DealerListViewModel
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
            return View("Dealer", Dealers);
        }

        [HttpPost]
        public JsonResult GetDealerReport(string Status)
        {

            var DealerDetails = _IDealerService.GetAllDealer(Status);
            return Json(DealerDetails, JsonRequestBehavior.AllowGet);
        }
    }
}