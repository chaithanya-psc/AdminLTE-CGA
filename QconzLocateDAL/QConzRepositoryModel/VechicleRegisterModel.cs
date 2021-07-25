using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryModel
{
    public class VechicleRegisterModel
    {
        public Int64 Id { get; set; }
        public string Number { get; set; }
        public DateTime? RegistratioDate { get; set; }
        public DateTime? PolutionDate { get; set; }
        public DateTime? InsuranceDate { get; set; }
        public DateTime? TestDate { get; set; }
        public string Remarks { get; set; }
    }
}
