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
        public string Adrees { get; set; }
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public DateTime JoinDate { get; set; }
        public string Remarks { get; set; }
    }
}
