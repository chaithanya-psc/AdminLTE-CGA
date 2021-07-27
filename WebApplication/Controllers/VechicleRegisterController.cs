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
    //public class VechicleRegisterController : Controller
    //{
    //    // GET: VechicleRegister
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [SessionExpireFilter]
    [Authorize(Roles = "SUPER,ADMIN")]
    public class VechicleRegisterController : Controller
    {
        private IVechicleRegisterService _IVechicleRegisterService = new VechicleRegisterService();
        private CommonService _commonService = new CommonService();
        // GET: VechicleRegister list
        public ActionResult VechicleRegisterReport()
        {

            VechicleRegisterRegisterModel VechicleRegister = new VechicleRegisterRegisterModel();
            var VechicleRegisters = _IVechicleRegisterService.GetAllVechicleRegister("A").Select(c => new VechicleRegisterListViewModel
            {
                Id = c.Id,
                Number = c.Number,
                RegisterDate = c.RegisterDate,
                PolutionDate = c.PolutionDate,
                TestDate = c.TestDate,
                InsuranceDate = c.InsuranceDate,
                Remarks = c.Remarks

            }).ToList();
            return View("VechicleRegisterList", VechicleRegisters);
        }

        //Get individual VechicleRegister
        public ActionResult VechicleRegisterRegister(Int64 id)
        {

            VechicleRegisterRegisterModel VechicleRegisterRegisterModel = new VechicleRegisterRegisterModel();
            VechicleRegisterListViewModel VechicleRegisterDetails;
            var c = _IVechicleRegisterService.GetVechicleRegisterDetails(id);
            if (id != 0)
            {
                VechicleRegisterDetails = new VechicleRegisterListViewModel
                {
                    Id = c.Id,
                    Number = c.Number,
                    RegisterDate = c.RegisterDate,
                    PolutionDate = c.PolutionDate,
                    TestDate = c.TestDate,
                    InsuranceDate = c.InsuranceDate,
                    Remarks = c.Remarks
                };

            }
            else
            {
                VechicleRegisterDetails = new VechicleRegisterListViewModel
                {
                    Id = 0,
                    Number = null,
                    RegisterDate = null,
                    PolutionDate = null,
                    TestDate = null,
                    InsuranceDate = null,
                    Remarks = null
                };
            }
            VechicleRegisterRegisterModel.VechicleRegisterDetails = VechicleRegisterDetails;


            return View("VechicleRegisterRegister", VechicleRegisterRegisterModel);
        }

        [HttpPost]
        public JsonResult SaveDetails(VechicleRegisterListViewModel VechicleRegister)
        {
            VechicleRegisterServiceModel VechicleRegisterModel;
            VechicleRegisterModel = new VechicleRegisterServiceModel()
            {
                Id = VechicleRegister.Id,
                Number = VechicleRegister.Number,
                RegisterDate = VechicleRegister.RegisterDate,
                PolutionDate = VechicleRegister.PolutionDate,
                TestDate = VechicleRegister.TestDate,
                InsuranceDate = VechicleRegister.InsuranceDate,
                Remarks = VechicleRegister.Remarks

            };
            _IVechicleRegisterService.SaveVechicleRegisterDetails(VechicleRegisterModel);
            bool success = true;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Download excel template
        public FileResult DownloadExcel()
        {
            string path = "~/Doc/VechicleRegister.xlsx";
            return File(path, "application/vnd.ms-excel", "VechicleRegister.xlsx");
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

                var VechicleRegisterBulk = result.Tables[0].Rows.Cast<DataRow>().Select(r => new VechicleRegisterServiceModel
                {

                    Number = r["Number"].ToString(),
                  
                    RegisterDate = Convert.ToDateTime(r["RegisterDate"]),
                    PolutionDate = Convert.ToDateTime(r["PolutionDate"]),
                    TestDate = Convert.ToDateTime(r["TestDate"]),
                    InsuranceDate = Convert.ToDateTime(r["InsuranceDate"]),

                    Remarks = r["Remarks"].ToString()
                }).ToList();
                _IVechicleRegisterService.SaveBulkVechicleRegisterDetails(VechicleRegisterBulk);

            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }


            VechicleRegisterRegisterModel VechicleRegister = new VechicleRegisterRegisterModel();
            var VechicleRegisters = _IVechicleRegisterService.GetAllVechicleRegister("A").Select(c => new VechicleRegisterListViewModel
            {
                Id = c.Id,
                Number = c.Number,
                RegisterDate = c.RegisterDate,
                PolutionDate = c.PolutionDate,
                TestDate = c.TestDate,
                InsuranceDate = c.InsuranceDate,
                Remarks = c.Remarks

            }).ToList();
            return View("VechicleRegister", VechicleRegisters);
        }

        [HttpPost]
        public JsonResult GetVechicleRegisterReport(string Status)
        {

            var VechicleRegisterDetails = _IVechicleRegisterService.GetAllVechicleRegister(Status);
            return Json(VechicleRegisterDetails, JsonRequestBehavior.AllowGet);
        }
    }
}