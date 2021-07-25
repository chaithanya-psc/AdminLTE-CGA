﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.Models
{
    public class StaffRegisterServiceModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string M_Licence1 { get; set; }
        public string M_Licence2 { get; set; }
        public string D_Licence { get; set; }
        public string E_Licence { get; set; }
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public string Email { get; set; }
        public string GST_Num { get; set; }
        public string Remarks { get; set; }
        public string Shop_StaffRegister { get; set; }
    }
}
