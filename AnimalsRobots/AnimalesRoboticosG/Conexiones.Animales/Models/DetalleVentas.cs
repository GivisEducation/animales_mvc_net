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
    using System.Collections.Generic;
    
    public partial class DetalleVentas
    {
        public int id { get; set; }
        public int idVenta { get; set; }
        public int idProducto { get; set; }
        public short cantidad { get; set; }
        public short subTotal { get; set; }
    
        public virtual Productos Productos { get; set; }
        public virtual Ventas Ventas { get; set; }
    }
}
