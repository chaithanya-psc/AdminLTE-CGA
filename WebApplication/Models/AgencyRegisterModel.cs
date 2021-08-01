using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QconzLocate.Models
{
    
    public class AgencyRegisterModel
    {
        public List<AgencyListViewModel> AgencyList { get; set; }
        public AgencyListViewModel AgencyDetails { get; set; }
       
    }
    public class AgencyListViewModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string M_Licence1 { get; set; }
        public string M_Licence2 { get; set; }
        public string D_Licence { get; set; }
        public string E_Licence { get; set; }
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public string Email { get; set; }
        public string GST_Num { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        public string Shop_Dealer { get; set; }
       
    }
}