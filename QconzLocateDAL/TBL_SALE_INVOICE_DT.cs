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
    
    public partial class TBL_SALE_INVOICE_DT
    {
        public long ID { get; set; }
        public long SALE_ID { get; set; }
        public long CYLINDER_ID { get; set; }
        public Nullable<decimal> HANDLING_CHARGE { get; set; }
        public Nullable<decimal> PURCHASE_AMOUNT { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public string REMARKS { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
    
        public virtual TBL_SALE_HD TBL_SALE_HD { get; set; }
    }
}