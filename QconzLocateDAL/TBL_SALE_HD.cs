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
    
    public partial class TBL_SALE_HD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_SALE_HD()
        {
            this.TBL_SALE_INVOICE_DT = new HashSet<TBL_SALE_INVOICE_DT>();
        }
    
        public long ID { get; set; }
        public long CUSTOMER_ID { get; set; }
        public string INVOICE_NUMER { get; set; }
        public string BILL_NUMER { get; set; }
        public System.DateTime SALE_DATE { get; set; }
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
    
        public virtual TBL_CUSTOMER_REGISTER TBL_CUSTOMER_REGISTER { get; set; }
        public virtual TBL_STAFF_REGISTER TBL_STAFF_REGISTER { get; set; }
        public virtual TBL_VECHICLE_REGISTER TBL_VECHICLE_REGISTER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SALE_INVOICE_DT> TBL_SALE_INVOICE_DT { get; set; }
    }
}
