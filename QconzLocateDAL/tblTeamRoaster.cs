//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QconzLocateDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTeamRoaster
    {
        public int ID { get; set; }
        public int TEAMID { get; set; }
        public int ROASTERID { get; set; }
        public string ARCHIVE { get; set; }
    
        public virtual tblRoaster tblRoaster { get; set; }
        public virtual tblTeam tblTeam { get; set; }
    }
}