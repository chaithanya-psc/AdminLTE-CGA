using QconzLocateDAL.QConzRepositoryInterface;
using QconzLocateDAL.QConzRepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        QCONZEntities entity = new QCONZEntities();

        public List<CustomerModel> GetAllCustomer(string Status)
        {
            try
            {
                List<CustomerModel> CustomerList = new List<CustomerModel>();
                var y = (from t in entity.TBL_CUSTOMER_REGISTER  select t).ToList();
                CustomerList = y.Select(c => new CustomerModel
                {
                    Id = c.ID,
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
                }
                ).ToList();
                return CustomerList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerModel GetCustomerDetails(int Id)
        {
            try
            {
                var y = (from c in entity.TBL_CUSTOMER_REGISTER
                         where c.ID == Id
                         select new CustomerModel
                         {
                             Id = c.ID,
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
                         }).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveCustomerDetails(CustomerModel c)
        {
            try
            {
                if (c.Id == 0)
                {
                    var customer = new TBL_CUSTOMER_REGISTER()
                    {
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
                    entity.TBL_CUSTOMER_REGISTER.Add(customer);
                }
                else
                {
                    var y = entity.TBL_CUSTOMER_REGISTER.FirstOrDefault(t => t.ID == c.Id);
                    y.NAME = c.NAME;
                    y.SHORT_NAME = c.SHORT_NAME;
                    y.MOB1 = c.MOB1;
                    y.MOB2 = c.MOB2;
                    y.EMAIL_ID = c.EMAIL_ID;
                    y.ADDRESS = c.ADDRESS;
                    y.DEPOSITE = c.DEPOSITE;
                    y.AGREEMENT_BILL_NUMER = c.AGREEMENT_BILL_NUMER;
                    y.ACTIVE = c.ACTIVE;
                    y.REGISTER_DATE = c.REGISTER_DATE;
                    y.IS_FLOW_METER_SALED = c.IS_FLOW_METER_SALED;
                    y.CLOSE_DATE = c.CLOSE_DATE;
                    y.DEPOSITE_RETURENED_AMOUNT = c.DEPOSITE_RETURENED_AMOUNT;
                    y.REMARKS = c.REMARKS;
                    y.MODE = c.MODE;
                  
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveBulkCustomerDetails(List<CustomerModel> CustomerModel)
        {
            try
            {
                
                var customers = entity.TBL_CUSTOMER_REGISTER;
                foreach (var item in customers)
                {
                    entity.TBL_CUSTOMER_REGISTER.Remove(item);
                }
                foreach (var item in CustomerModel)
                {
                    var customer = new TBL_CUSTOMER_REGISTER()
                    {
                        NAME = item.NAME,
                        SHORT_NAME = item.SHORT_NAME,
                        MOB1 = item.MOB1,
                        MOB2 = item.MOB2,
                        EMAIL_ID = item.EMAIL_ID,
                        ADDRESS = item.ADDRESS,
                        DEPOSITE = item.DEPOSITE,
                        AGREEMENT_BILL_NUMER = item.AGREEMENT_BILL_NUMER,
                        ACTIVE = item.ACTIVE,
                        REGISTER_DATE = item.REGISTER_DATE,
                        IS_FLOW_METER_SALED = item.IS_FLOW_METER_SALED,
                        CLOSE_DATE = item.CLOSE_DATE,
                        DEPOSITE_RETURENED_AMOUNT = item.DEPOSITE_RETURENED_AMOUNT,
                        REMARKS = item.REMARKS,
                        MODE = item.MODE
                    };
                    entity.TBL_CUSTOMER_REGISTER.Add(customer);
                }
                entity.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
