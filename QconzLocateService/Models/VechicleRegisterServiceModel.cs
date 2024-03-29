﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateService.Models
{
    public class VechicleRegisterServiceModel
    {
        public Int64 Id { get; set; }
        public string Number { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? PolutionDate { get; set; }
        public DateTime? InsuranceDate { get; set; }
        public DateTime? TestDate { get; set; }
        public string Remarks { get; set; }
    }
}
