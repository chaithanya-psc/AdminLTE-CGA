using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QconzLocate.Models
{

    public class CylinderRegisterRegisterModel
    {
        public List<CylinderRegisterListViewModel> CylinderRegisterList { get; set; }
        public CylinderRegisterListViewModel CylinderRegisterDetails { get; set; }

    }
    public class CylinderRegisterListViewModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string HSN_Code { get; set; }

        public int? RentDaysSlab1 { get; set; }
        public int? RentDaysSlab2 { get; set; }
        public decimal? SellingAmount { get; set; }
        public string Remarks { get; set; }

    }
}