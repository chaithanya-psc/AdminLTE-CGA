﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QCONZEntities : DbContext
    {
        public QCONZEntities()
            : base("name=QCONZEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_CUSTOMER_PAYMENT_DT> TBL_CUSTOMER_PAYMENT_DT { get; set; }
        public virtual DbSet<TBL_CUSTOMER_PAYMENT_HD> TBL_CUSTOMER_PAYMENT_HD { get; set; }
        public virtual DbSet<TBL_CUSTOMER_REGISTER> TBL_CUSTOMER_REGISTER { get; set; }
        public virtual DbSet<TBL_CYLINDER_MASTER> TBL_CYLINDER_MASTER { get; set; }
        public virtual DbSet<TBL_CYLINDER_TRACKING> TBL_CYLINDER_TRACKING { get; set; }
        public virtual DbSet<TBL_DEALER_PAYMENT_DT> TBL_DEALER_PAYMENT_DT { get; set; }
        public virtual DbSet<TBL_DEALER_PAYMENT_HD> TBL_DEALER_PAYMENT_HD { get; set; }
        public virtual DbSet<TBL_OWN_CYLINDER_REGISTER> TBL_OWN_CYLINDER_REGISTER { get; set; }
        public virtual DbSet<TBL_PURCHASE_HD> TBL_PURCHASE_HD { get; set; }
        public virtual DbSet<TBL_PURCHASE_INVOICE_DT> TBL_PURCHASE_INVOICE_DT { get; set; }
        public virtual DbSet<TBL_SALE_HD> TBL_SALE_HD { get; set; }
        public virtual DbSet<TBL_SALE_INVOICE_DT> TBL_SALE_INVOICE_DT { get; set; }
        public virtual DbSet<TBL_SHOP_DEALER_BANK_DETAILS> TBL_SHOP_DEALER_BANK_DETAILS { get; set; }
        public virtual DbSet<TBL_SHOP_DEALER_REGISTER> TBL_SHOP_DEALER_REGISTER { get; set; }
        public virtual DbSet<TBL_STAFF_REGISTER> TBL_STAFF_REGISTER { get; set; }
        public virtual DbSet<TBL_STAFF_REGISTER_DT> TBL_STAFF_REGISTER_DT { get; set; }
        public virtual DbSet<TBL_VECHICLE_REGISTER> TBL_VECHICLE_REGISTER { get; set; }
        public virtual DbSet<TBL_VECHICLE_REGISTER_DT> TBL_VECHICLE_REGISTER_DT { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblEmergency> tblEmergencies { get; set; }
        public virtual DbSet<tblNotification> tblNotifications { get; set; }
        public virtual DbSet<tblOrganization> tblOrganizations { get; set; }
        public virtual DbSet<tblRoaster> tblRoasters { get; set; }
        public virtual DbSet<tblStopTracking> tblStopTrackings { get; set; }
        public virtual DbSet<tblTeamRoaster> tblTeamRoasters { get; set; }
        public virtual DbSet<tblTeam> tblTeams { get; set; }
        public virtual DbSet<tblUserLog> tblUserLogs { get; set; }
        public virtual DbSet<tblUserMaster> tblUserMasters { get; set; }
        public virtual DbSet<tblUserRoaster> tblUserRoasters { get; set; }
        public virtual DbSet<tblUserTeam> tblUserTeams { get; set; }
    }
}
