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
    
    public partial class TBL_CUSTOMER_PAYMENT_DT
    {
        public long ID { get; set; }
        public long CUSTOMER_PAYMENT_ID { get; set; }
        public System.DateTime PAYMENT_DATE { get; set; }
        public Nullable<decimal> CURRENT_PURCHASE_AMOUNT { get; set; }
        public Nullable<decimal> CURRENT_RENT_AMOUNT { get; set; }
        public Nullable<decimal> CURRENT_HANDLING_AMOUNT { get; set; }
        public Nullable<decimal> CURRENT_VECHICLE_AMOUNT { get; set; }
        public Nullable<decimal> CURRENT_OTHER_AMOUNT { get; set; }
        public Nullable<decimal> PAID_PURCHASE_AMOUNT { get; set; }
        public Nullable<decimal> PAID_RENT_AMOUNT { get; set; }
        public Nullable<decimal> PAID_HANDLING_AMOUNT { get; set; }
        public Nullable<decimal> PAID_VECHICLE_AMOUNT { get; set; }
        public Nullable<decimal> PAID_OTHER_AMOUNT { get; set; }
        public string REMARKS { get; set; }
        public Nullable<long> SALE_ID { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
    
        public virtual TBL_CUSTOMER_PAYMENT_HD TBL_CUSTOMER_PAYMENT_HD { get; set; }
    }
}
