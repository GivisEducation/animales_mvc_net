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
    
    public partial class Ventas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ventas()
        {
            this.DetalleVentas = new HashSet<DetalleVentas>();
            this.Pedidos = new HashSet<Pedidos>();
        }
    
        public int id { get; set; }
        public System.DateTime fecha { get; set; }
        public short total { get; set; }
        public int idUsuario { get; set; }
        public string descripcion { get; set; }
        public int idMetodoPago { get; set; }
        public bool eliminado { get; set; }
        public Nullable<System.DateTime> fechaEliminacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVentas> DetalleVentas { get; set; }
        public virtual MetodoPagos MetodoPagos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
