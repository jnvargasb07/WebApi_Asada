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
    
    public partial class Reciclaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reciclaje()
        {
            this.Reciclaje1 = new HashSet<Reciclaje>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_material { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<double> Precio_kilo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> Numero_boleta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reciclaje> Reciclaje1 { get; set; }
        public virtual Reciclaje Reciclaje2 { get; set; }
    }
}
