using ExcelDataReader;
using QconzLocate.Models;
using QconzLocateService.Models;
using QconzLocateService.QconzLocateInterface;
using QconzLocateService.QconzLocateService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QconzLocate.Controllers
{
    [SessionExpireFilter]
    [Authorize(Roles = "SUPER,ADMIN")]
    public class CustomerController : Controller
    {
        private ICustomerService _ICustomerService = new CustomerService();
        private CommonService _commonService = new CommonService();
        // GET: Customer list
        public ActionResult CustomerReport()
        {
          
            CustomerViewModel customer = new CustomerViewModel();
            var customers  = _ICustomerService.GetAllCustomer("A").Select(c => new CustomerListViewModel
            {
                Id = c.Id,
        NAME= c.NAME,
        SHORT_NAME =c.SHORT_NAME,
        MOB1 =c.MOB1,
        MOB2 =c.MOB2,
        EMAIL_ID =c.EMAIL_ID,
        ADDRESS =c.ADDRESS,
        DEPOSITE =c.DEPOSITE,
        AGREEMENT_BILL_NUMER =c.AGREEMENT_BILL_NUMER,
         ACTIVE =c.ACTIVE,
        REGISTER_DATE =c.REGISTER_DATE,
         IS_FLOW_METER_SALED=c.IS_FLOW_METER_SALED,
        CLOSE_DATE=c.CLOSE_DATE,
         DEPOSITE_RETURENED_AMOUNT=c.DEPOSITE_RETURENED_AMOUNT,
        REMARKS =c.REMARKS,
        MODE =c.MODE
            }).ToList();
            return View("Customer", customers);
        }

        //Get individual customer
        public ActionResult CustomerDetails(int id)
        {
           
            CustomerViewModel CustomerViewModel = new CustomerViewModel();
            CustomerListViewModel CustomerDetails;
            var c = _ICustomerService.GetCustomerDetails(id);
            if (id != 0)
            {
                CustomerDetails = new CustomerListViewModel
                {
                    Id = c.Id,
                    NAME = c.NAME,
                    SHORT_NAME = c.SHORT_NAME,
                    MOB1 = c.MOB1,
                    MOB2 = c.MOB2,
                    EMAIL_ID = c.EMAIL_ID,
                    ADDRESS = c.ADDRESS,
                    DEPOSITE = c.DEPOSITE,
                    AGREEMENT_BILL_NUMER = c.AGREEMENT_BILL_NUMER,
                    ACTIVE = c.ACTIVE,
                    REGISTER_DATE = c.REGISTER_DATE,
                    IS_FLOW_METER_SALED = c.IS_FLOW_METER_SALED,
                    CLOSE_DATE = c.CLOSE_DATE,
                    DEPOSITE_RETURENED_AMOUNT = c.DEPOSITE_RETURENED_AMOUNT,
                    REMARKS = c.REMARKS,
                    MODE = c.MODE
                };
                
            }
            else
            {
                CustomerDetails = new CustomerListViewModel
                {
                    Id = 0,
                    NAME = null,
                    SHORT_NAME = null,
                    MOB1 = null,
                    MOB2 = null,
                    EMAIL_ID = null,
                    ADDRESS = null,
                    DEPOSITE = null,
                    AGREEMENT_BILL_NUMER = null,
                    ACTIVE = false,
                    REGISTER_DATE = null,
                    IS_FLOW_METER_SALED = false,
                    CLOSE_DATE = null,
                    DEPOSITE_RETURENED_AMOUNT = null,
                    REMARKS = null,
                    MODE = null
                };
            }
            CustomerViewModel.CustomerDetails = CustomerDetails;
           
           
            return View("CustomerDetails", CustomerViewModel);
        }

        [HttpPost]
        public JsonResult SaveDetails(CustomerListViewModel c)
        {
            CustomerServiceModel CustomerModel;
            CustomerModel = new CustomerServiceModel()
            {
                Id = c.Id,
                NAME = c.NAME,
                SHORT_NAME = c.SHORT_NAME,
                MOB1 = c.MOB1,
                MOB2 = c.MOB2,
                EMAIL_ID = c.EMAIL_ID,
                ADDRESS = c.ADDRESS,
                DEPOSITE = c.DEPOSITE,
                AGREEMENT_BILL_NUMER = c.AGREEMENT_BILL_NUMER,
                ACTIVE = c.ACTIVE,
                REGISTER_DATE = c.REGISTER_DATE,
                IS_FLOW_METER_SALED = c.IS_FLOW_METER_SALED,
                CLOSE_DATE = c.CLOSE_DATE,
                DEPOSITE_RETURENED_AMOUNT = c.DEPOSITE_RETURENED_AMOUNT,
                REMARKS = c.REMARKS,
                MODE = c.MODE
            };
            _ICustomerService.SaveCustomerDetails(CustomerModel);
            bool success = true;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Download excel template
        public FileResult DownloadExcel()
        {
            string path = "~/Doc/Customer.xlsx";
            return File(path, "application/vnd.ms-excel", "Customer.xlsx");
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

                var CustomerBulk = result.Tables[0].Rows.Cast<DataRow>().Select(r => new CustomerServiceModel
                {
                   
                    NAME = r["NAME"].ToString(),
                    SHORT_NAME = r["SHORT_NAME"].ToString(),
                    MOB1 = r["MOB1"].ToString(),
                    MOB2 = r["MOB2"].ToString(),
                    EMAIL_ID = r["EMAIL_ID"].ToString(),
                    ADDRESS = r["ADDRESS"].ToString(),
                    DEPOSITE =Convert.ToDecimal(r["DEPOSITE"]),
                    AGREEMENT_BILL_NUMER =Convert.ToInt32(r["AGREEMENT_BILL_NUMER"]),
                    ACTIVE =  Convert.ToBoolean(r["ACTIVE"]),
                    REGISTER_DATE = Convert.ToDateTime(r["REGISTER_DATE"]),
                    IS_FLOW_METER_SALED =  Convert.ToBoolean(r["IS_FLOW_METER_SALED"]),
                    CLOSE_DATE = Convert.ToDateTime(r["CLOSE_DATE"]),
                    DEPOSITE_RETURENED_AMOUNT = Convert.ToDecimal(r["DEPOSITE_RETURENED_AMOUNT"]),
                    REMARKS = r["REMARKS"].ToString(),
                    MODE = r["MODE"].ToString(),
                }).ToList();
                _ICustomerService.SaveBulkCustomerDetails(CustomerBulk);
                
            }
            else
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }

           
            CustomerViewModel customer = new CustomerViewModel();
            var customers = _ICustomerService.GetAllCustomer("A").Select(c => new CustomerListViewModel
            {
                Id = c.Id,
                NAME = c.NAME,
                SHORT_NAME = c.SHORT_NAME,
                MOB1 = c.MOB1,
                MOB2 = c.MOB2,
                EMAIL_ID = c.EMAIL_ID,
                ADDRESS = c.ADDRESS,
                DEPOSITE = c.DEPOSITE,
                AGREEMENT_BILL_NUMER = c.AGREEMENT_BILL_NUMER,
                ACTIVE = c.ACTIVE,
                REGISTER_DATE = c.REGISTER_DATE,
                IS_FLOW_METER_SALED = c.IS_FLOW_METER_SALED,
                CLOSE_DATE = c.CLOSE_DATE,
                DEPOSITE_RETURENED_AMOUNT = c.DEPOSITE_RETURENED_AMOUNT,
                REMARKS = c.REMARKS,
                MODE = c.MODE
            }).ToList();
            return View("Customer", customers);
        }

        [HttpPost]
        public JsonResult GetCustomerReport(string Status)
        {
       
            var CompanyList = _ICustomerService.GetAllCustomer(Status );
            return Json(CompanyList, JsonRequestBehavior.AllowGet);
        }
    }
}