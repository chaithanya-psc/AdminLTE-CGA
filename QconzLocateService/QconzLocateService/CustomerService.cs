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
    public class CustomerService: ICustomerService
    {
        private ICustomerRepository _ICustomerRepository = new CustomerRepository();
        //Get all companies
        public List<CustomerServiceModel> GetAllCustomer(string Status)
        {
            try
            {
                var y = _ICustomerRepository.GetAllCustomer(Status);
                return y.Select(c => new CustomerServiceModel
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
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Get companies by Id

        public CustomerServiceModel GetCustomerDetails(int Id)
        {
            try
            {
                var c = _ICustomerRepository.GetCustomerDetails(Id);
                return new CustomerServiceModel
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
            catch
            {
                return null;
            }
        }

        public void SaveCustomerDetails(CustomerServiceModel c)
        {

            var customer = new CustomerModel()
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
            _ICustomerRepository.SaveCustomerDetails(customer);
        }

        public void SaveBulkCustomerDetails(List<CustomerServiceModel> CustomerDetails)
        {

            var customer = CustomerDetails.Select(c=> new CustomerModel()
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
            _ICustomerRepository.SaveBulkCustomerDetails(customer);
        }
    }
}
