using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QconzLocateDAL.QConzRepositoryModel
{
    public class DealerModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
     
        public string Mob1 { get; set; }
        public string Mob2 { get; set; }
        public string Email { get; set; }
        public string GST_Num { get; set; }
        public string Remarks { get; set; }
        public string Shop_Dealer { get; set; }
    }
}
