﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCuaHangTapHoa.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class quantaphoaEntities : DbContext
    {
        public quantaphoaEntities()
            : base("name=quantaphoaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Order_Status> Order_Status { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
