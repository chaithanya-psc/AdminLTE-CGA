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
    //public class StaffRegisterController : Controller
    //{
    //    // GET: StaffRegister
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [SessionExpireFilter]
    [Authorize(Roles = "SUPER,ADMIN")]
    public class StaffRegisterController : Controller
    {
        private IStaffRegisterService _IStaffRegisterService = new StaffRegisterService();
        private CommonService _commonService = new CommonService();
        // GET: StaffRegister list
        public ActionResult StaffRegisterReport()
        {

            StaffRegisterRegisterModel StaffRegister = new StaffRegisterRegisterModel();
            var StaffRegisters = _IStaffRegisterService.GetAllStaffRegister("A").Select(c => new StaffRegisterListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
               
                Mob1 = c.Mob1,
                Mob2 = c.Mob2,
                JoinDate = c.JoinDate,
                Remarks = c.Remarks
               
            }).ToList();
            return View("StaffRegisterList", StaffRegisters);
        }

        //Get individual StaffRegister
        public ActionResult StaffRegisterRegister(Int64 id)
        {

            StaffRegisterRegisterModel StaffRegisterRegisterModel = new StaffRegisterRegisterModel();
            StaffRegisterListViewModel StaffRegisterDetails;
            var c = _IStaffRegisterService.GetStaffRegisterDetails(id);
            if (id != 0)
            {
                StaffRegisterDetails = new StaffRegisterListViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,

                    Mob1 = c.Mob1,
                    Mob2 = c.Mob2,
                    JoinDate = c.JoinDate,
                    Remarks = c.Remarks
                };

            }
            else
            {
                StaffRegisterDetails = new StaffRegisterListViewModel
                {
                    Id = 0,
                    Name = null,
                    Address = null,
                  
                    Mob1 = null,
                    Mob2 = null,
                    
                    Remarks = null,
                   
                    JoinDate =DateTime.Now
                };
            }
            StaffRegisterRegisterModel.StaffRegisterDetails = StaffRegisterDetails;


            return View("StaffRegisterRegister", StaffRegisterRegisterModel);
        }

        [HttpPost]
        public JsonResult SaveDetails(StaffRegisterListViewModel StaffRegister)
        {
            StaffRegisterServiceModel StaffRegisterModel;
            StaffRegisterModel = new StaffRegisterServiceModel()
            {
                Id = StaffRegister.Id,
                Name = StaffRegister.Name,
                Address = StaffRegister.Address,
                JoinDate = StaffRegister.JoinDate,
                Mob1 = StaffRegister.Mob1,
                Mob2 = StaffRegister.Mob2,
             
                Remarks = StaffRegister.Remarks
             
            };
            _IStaffRegisterService.SaveStaffRegisterDetails(StaffRegisterModel);
            bool success = true;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Download excel template
        public FileResult DownloadExcel()
        {
            string path = "~/Doc/StaffRegister.xlsx";
            return File(path, "application/vnd.ms-excel", "StaffRegister.xlsx");
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

                var StaffRegisterBulk = result.Tables[0].Rows.Cast<DataRow>().Select(r => new StaffRegisterServiceModel
                {

                    Address = r["Address"].ToString(),
                    Name = r["Name"].ToString(),
                    JoinDate =Convert.ToDateTime(r["JoinDate"]),
                   
                    Mob1 = r["Mob1"].ToString(),
                    Mob2 = r["Mob2"].ToString(),
                   
                    Remarks = "SH"
                }).ToList();
                _IStaffRegisterService.SaveBulkStaffRegisterDetails(StaffRegisterBulk);

            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }


            StaffRegisterRegisterModel StaffRegister = new StaffRegisterRegisterModel();
            var StaffRegisters = _IStaffRegisterService.GetAllStaffRegister("A").Select(c => new StaffRegisterListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                JoinDate = c.JoinDate,
                Mob1 = c.Mob1,
                Mob2 = c.Mob2,
                
                Remarks = c.Remarks
               
            }).ToList();
            return View("StaffRegister", StaffRegisters);
        }

        [HttpPost]
        public JsonResult GetStaffRegisterReport(string Status)
        {

            var StaffRegisterDetails = _IStaffRegisterService.GetAllStaffRegister(Status);
            return Json(StaffRegisterDetails, JsonRequestBehavior.AllowGet);
        }
    }
}