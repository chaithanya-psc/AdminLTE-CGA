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
    
    public partial class TBL_CYLINDER_TRACKING
    {
        public long ID { get; set; }
        public long PURCHASE_ID { get; set; }
        public Nullable<long> PARENT_CYLINDER_ID { get; set; }
        public string CHALLAN_NUMBER { get; set; }
        public long CYLINDER_TYPE_ID { get; set; }
        public decimal CYLINDER_QUANTITY { get; set; }
        public decimal CYLINDER_NUMBER { get; set; }
        public string OWN_CYLINDER { get; set; }
        public string IS_COMPLAINT { get; set; }
        public string SALED_TO_CUSTOMER { get; set; }
        public Nullable<System.DateTime> SALED_TO_CUSTOMER_DATE { get; set; }
        public string RETURN_FROM_CUSTOMER { get; set; }
        public Nullable<System.DateTime> RETURN_FROM_CUSTOMER_DATE { get; set; }
        public string RETURN_TO_DEALER { get; set; }
        public Nullable<System.DateTime> RETURN_TO_DEALER_DATE { get; set; }
        public string ACTUAL_DEALER_RETURN { get; set; }
        public string REMARKS { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
    
        public virtual TBL_CYLINDER_MASTER TBL_CYLINDER_MASTER { get; set; }
        public virtual TBL_PURCHASE_HD TBL_PURCHASE_HD { get; set; }
    }
}
