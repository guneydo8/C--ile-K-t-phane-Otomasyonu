﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KütüphaneOtomasyonu.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MvcKütüphaneEntities : DbContext
    {
        public MvcKütüphaneEntities()
            : base("name=MvcKütüphaneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblKasa> TblKasa { get; set; }
        public virtual DbSet<TblKategoriler> TblKategoriler { get; set; }
        public virtual DbSet<TblKitaplar> TblKitaplar { get; set; }
        public virtual DbSet<TblPersonel> TblPersonel { get; set; }
        public virtual DbSet<TblYazar> TblYazar { get; set; }
        public virtual DbSet<TblHakkımızda> TblHakkımızda { get; set; }
        public virtual DbSet<Tblİletişim> Tblİletişim { get; set; }
        public virtual DbSet<TblMesajlar> TblMesajlar { get; set; }
        public virtual DbSet<TblCezalar> TblCezalar { get; set; }
        public virtual DbSet<Tblİşlemler> Tblİşlemler { get; set; }
        public virtual DbSet<TblDuyurular> TblDuyurular { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblÜyeler> TblÜyeler { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
    
        public virtual ObjectResult<string> maxkitaplıyazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("maxkitaplıyazar");
        }
    
        public virtual ObjectResult<string> enbasarılıpersonel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enbasarılıpersonel");
        }
    
        public virtual ObjectResult<string> enaktifüye()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enaktifüye");
        }
    
        public virtual ObjectResult<string> encokokunankitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("encokokunankitap");
        }
    }
}
