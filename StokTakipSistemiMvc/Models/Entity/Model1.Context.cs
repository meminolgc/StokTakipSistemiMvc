﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipSistemiMvc.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbStokMvcEntities : DbContext
    {
        public DbStokMvcEntities()
            : base("name=DbStokMvcEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblkategori> tblkategori { get; set; }
        public virtual DbSet<tblkmusteri> tblkmusteri { get; set; }
        public virtual DbSet<tblpersonel> tblpersonel { get; set; }
        public virtual DbSet<tblsatislar> tblsatislar { get; set; }
        public virtual DbSet<tblurunler> tblurunler { get; set; }
    }
}
