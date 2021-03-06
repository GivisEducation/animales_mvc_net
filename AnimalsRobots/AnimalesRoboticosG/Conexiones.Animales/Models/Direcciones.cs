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
    
    public partial class Direcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direcciones()
        {
            this.Pedidos = new HashSet<Pedidos>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public int idComuna { get; set; }
        public int idUsuario { get; set; }
        public string codigoPostal { get; set; }
        public string referencias { get; set; }
        public string recibidor { get; set; }
        public string numero { get; set; }
        public bool departamento { get; set; }
        public bool principal { get; set; }
        public bool eliminado { get; set; }
        public Nullable<System.DateTime> fechaEliminacion { get; set; }
    
        public virtual Comunas Comunas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
