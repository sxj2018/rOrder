﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MySaleOrderEntities : DbContext
    {
        public MySaleOrderEntities()
            : base("name=MySaleOrderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<SaleProduct> SaleProduct { get; set; }
        public virtual DbSet<SaleOrder> SaleOrder { get; set; }
        public virtual DbSet<SaleBrands> SaleBrands { get; set; }
        public virtual DbSet<SaleCatalog> SaleCatalog { get; set; }
        public virtual DbSet<SaleCustom> SaleCustom { get; set; }
        public virtual DbSet<SaleOrderProlist> SaleOrderProlist { get; set; }

        


    }
}
