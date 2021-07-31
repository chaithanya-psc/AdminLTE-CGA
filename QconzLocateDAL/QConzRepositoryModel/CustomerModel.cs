using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryModel
{
    public class CustomerModel
    {
        public Int64 Id { get; set; }
        public string NAME { get; set; }
        public string SHORT_NAME { get; set; }
        public string MOB1 { get; set; }
        public string MOB2 { get; set; }
        public string EMAIL_ID { get; set; }
        public string ADDRESS { get; set; }
        public decimal? DEPOSITE { get; set; }
        public int? AGREEMENT_BILL_NUMER { get; set; }
        public bool? ACTIVE { get; set; }
        public DateTime? REGISTER_DATE { get; set; }
        public bool? IS_FLOW_METER_SALED { get; set; }
        public DateTime? CLOSE_DATE { get; set; }
        public decimal? DEPOSITE_RETURENED_AMOUNT { get; set; }
        public string REMARKS { get; set; }
        public string MODE { get; set; }
    }
}
