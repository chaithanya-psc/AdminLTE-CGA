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
    //public class CylinderRegisterController : Controller
    //{
    //    // GET: CylinderRegister
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [SessionExpireFilter]
    [Authorize(Roles = "SUPER,ADMIN")]
    public class CylinderRegisterController : Controller
    {
        private ICylinderRegisterService _ICylinderRegisterService = new CylinderRegisterService();
        private CommonService _commonService = new CommonService();
        // GET: CylinderRegister list
        public ActionResult CylinderRegisterReport()
        {

            CylinderRegisterRegisterModel CylinderRegister = new CylinderRegisterRegisterModel();
            var CylinderRegisters = _ICylinderRegisterService.GetAllCylinderRegister("A").Select(c => new CylinderRegisterListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ShortName = c.ShortName,
                HSN_Code = c.HSN_Code,
                Remarks = c.Remarks,
                RentDaysSlab1 = c.RentDaysSlab1,
                RentDaysSlab2 = c.RentDaysSlab2,
                SellingAmount = c.SellingAmount
                
            }).ToList();
            return View("CylinderRegisterList", CylinderRegisters);
        }

        //Get individual CylinderRegister
        public ActionResult CylinderRegisterRegister(Int64 id)
        {

            CylinderRegisterRegisterModel CylinderRegisterRegisterModel = new CylinderRegisterRegisterModel();
            CylinderRegisterListViewModel CylinderRegisterDetails;
            var c = _ICylinderRegisterService.GetCylinderRegisterDetails(id);
            if (id != 0)
            {
                CylinderRegisterDetails = new CylinderRegisterListViewModel
                {
                    Id = c.Id,
                    Name=c.Name,
                    ShortName = c.ShortName,
                    HSN_Code = c.HSN_Code,
                    Remarks = c.Remarks,
                    RentDaysSlab1 = c.RentDaysSlab1,
                    RentDaysSlab2 = c.RentDaysSlab2,
                    SellingAmount = c.SellingAmount
                };

            }
            else
            {
                CylinderRegisterDetails = new CylinderRegisterListViewModel
                {
                    Id = 0,
                    Name = null,
                    ShortName = null,
                    HSN_Code = null,
                    Remarks = null,
                    RentDaysSlab1 = null,
                    RentDaysSlab2 = null,
                    SellingAmount = null,
                };
            }
            CylinderRegisterRegisterModel.CylinderRegisterDetails = CylinderRegisterDetails;


            return View("CylinderRegisterRegister", CylinderRegisterRegisterModel);
        }

        [HttpPost]
        public JsonResult SaveDetails(CylinderRegisterListViewModel CylinderRegister)
        {
            CylinderRegisterServiceModel CylinderRegisterModel;
            CylinderRegisterModel = new CylinderRegisterServiceModel()
            {
                Id = CylinderRegister.Id,
                Name = CylinderRegister.Name,
                ShortName = CylinderRegister.ShortName,
                HSN_Code = CylinderRegister.HSN_Code,
                Remarks = CylinderRegister.Remarks,
                RentDaysSlab1 = CylinderRegister.RentDaysSlab1,
                RentDaysSlab2 = CylinderRegister.RentDaysSlab2,
                SellingAmount = CylinderRegister.SellingAmount
            };
            _ICylinderRegisterService.SaveCylinderRegisterDetails(CylinderRegisterModel);
            bool success = true;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Download excel template
        public FileResult DownloadExcel()
        {
            string path = "~/Doc/CylinderRegister.xlsx";
            return File(path, "application/vnd.ms-excel", "CylinderRegister.xlsx");
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

                var CylinderRegisterBulk = result.Tables[0].Rows.Cast<DataRow>().Select(r => new CylinderRegisterServiceModel
                {

                    Name = r["Name"].ToString(),
                    ShortName = r["ShortName"].ToString(),
                    HSN_Code = r["HSN_Code"].ToString(),
                    Remarks = r["Remarks"].ToString(),
                    RentDaysSlab1 = Convert.ToInt32(r["RentDaysSlab1"].ToString()),
                    RentDaysSlab2 = Convert.ToInt32(r["RentDaysSlab2"].ToString()),
                    SellingAmount = Convert.ToDecimal(r["SellingAmount"].ToString()),


                }).ToList();
                _ICylinderRegisterService.SaveBulkCylinderRegisterDetails(CylinderRegisterBulk);

            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }


            CylinderRegisterRegisterModel CylinderRegister = new CylinderRegisterRegisterModel();
            var CylinderRegisters = _ICylinderRegisterService.GetAllCylinderRegister("A").Select(c => new CylinderRegisterListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ShortName = c.ShortName,
                HSN_Code = c.HSN_Code,
                Remarks = c.Remarks,
                RentDaysSlab1 = c.RentDaysSlab1,
                RentDaysSlab2 = c.RentDaysSlab2,
                SellingAmount = c.SellingAmount
            }).ToList();
            return View("CylinderRegister", CylinderRegisters);
        }

        [HttpPost]
        public JsonResult GetCylinderRegisterReport(string Status)
        {

            var CylinderRegisterDetails = _ICylinderRegisterService.GetAllCylinderRegister(Status);
            return Json(CylinderRegisterDetails, JsonRequestBehavior.AllowGet);
        }
    }
}