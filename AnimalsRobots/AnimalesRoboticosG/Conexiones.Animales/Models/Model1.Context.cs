//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conexiones.Animales.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComercioRoboticoEntities : DbContext
    {
        public ComercioRoboticoEntities()
            : base("name=ComercioRoboticoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comunas> Comunas { get; set; }
        public virtual DbSet<DetalleVentas> DetalleVentas { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ImagenesProductos> ImagenesProductos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<DetallePedidos> DetallePedidos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<MetodoPagos> MetodoPagos { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
    }
}
