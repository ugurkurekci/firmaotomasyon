﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirmaOtomasyonUygulaması
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class firmaEntities : DbContext
    {
        public firmaEntities()
            : base("name=firmaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<müsteriKayit> müsteriKayit { get; set; }
        public virtual DbSet<satisYapilan> satisYapilans { get; set; }
        public virtual DbSet<ürünKayit> ürünKayit { get; set; }
        public virtual DbSet<yetkiliData> yetkiliDatas { get; set; }
    }
}
