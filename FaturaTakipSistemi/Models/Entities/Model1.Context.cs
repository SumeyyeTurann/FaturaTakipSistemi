﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FaturaTakipSistemi.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ftrTakipEntities : DbContext
    {
        public ftrTakipEntities()
            : base("name=ftrTakipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abone> Abone { get; set; }
        public virtual DbSet<DGaz> DGaz { get; set; }
        public virtual DbSet<Elektrik> Elektrik { get; set; }
        public virtual DbSet<Hizmet> Hizmet { get; set; }
        public virtual DbSet<Internet> Internet { get; set; }
        public virtual DbSet<kullanici> kullanici { get; set; }
        public virtual DbSet<Su> Su { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }
    }
}
