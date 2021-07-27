using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QconzLocate.Models
{

    public class VechicleRegisterRegisterModel
    {
        public List<VechicleRegisterListViewModel> VechicleRegisterList { get; set; }
        public VechicleRegisterListViewModel VechicleRegisterDetails { get; set; }

    }
    public class VechicleRegisterListViewModel
    {
        public Int64 Id { get; set; }
        public string Number { get; set; }


        public DateTime? RegisterDate { get; set; }
        public DateTime? PolutionDate { get; set; }
        public DateTime? TestDate { get; set; }
        public DateTime? InsuranceDate { get; set; }
        public String Remarks { get; set; }

    }
}