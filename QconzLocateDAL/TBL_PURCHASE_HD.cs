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
    
    public partial class TBL_PURCHASE_HD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PURCHASE_HD()
        {
            this.TBL_CYLINDER_TRACKING = new HashSet<TBL_CYLINDER_TRACKING>();
            this.TBL_PURCHASE_INVOICE_DT = new HashSet<TBL_PURCHASE_INVOICE_DT>();
        }
    
        public long ID { get; set; }
        public long DEALER_ID { get; set; }
        public string INVOICE_NUMER { get; set; }
        public string BILL_NUMER { get; set; }
        public System.DateTime PURCHASE_DATE { get; set; }
        public Nullable<long> STAFF_ID { get; set; }
        public Nullable<long> VECHICLE_ID { get; set; }
        public int TOTAL_CYLINDER { get; set; }
        public Nullable<decimal> VECHICLE_AMOUNT { get; set; }
        public Nullable<decimal> HANDLING_CHARGE { get; set; }
        public Nullable<decimal> PURCHASE_AMOUNT { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public string REMARKS { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CYLINDER_TRACKING> TBL_CYLINDER_TRACKING { get; set; }
        public virtual TBL_SHOP_DEALER_REGISTER TBL_SHOP_DEALER_REGISTER { get; set; }
        public virtual TBL_STAFF_REGISTER TBL_STAFF_REGISTER { get; set; }
        public virtual TBL_VECHICLE_REGISTER TBL_VECHICLE_REGISTER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PURCHASE_INVOICE_DT> TBL_PURCHASE_INVOICE_DT { get; set; }
    }
}
