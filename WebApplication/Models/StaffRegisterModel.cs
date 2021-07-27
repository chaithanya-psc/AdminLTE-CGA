using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QconzLocate.Models
{

    public class StaffRegisterRegisterModel
    {
        public List<StaffRegisterListViewModel> StaffRegisterList { get; set; }
        public StaffRegisterListViewModel StaffRegisterDetails { get; set; }

    }
    public class StaffRegisterListViewModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
     
  
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
       
        public string Address { get; set; }
        public string Remarks { get; set; }
        public DateTime JoinDate { get; set; }

    }
}