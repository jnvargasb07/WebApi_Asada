//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiAsada.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registro_Salidas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registro_Salidas()
        {
            this.Prestamos_Inventario = new HashSet<Prestamos_Inventario>();
            this.Salidas_Inventario = new HashSet<Salidas_Inventario>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Motivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamos_Inventario> Prestamos_Inventario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salidas_Inventario> Salidas_Inventario { get; set; }
    }
}
