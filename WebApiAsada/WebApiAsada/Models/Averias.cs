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
    
    public partial class Averias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Averias()
        {
            this.Inventario_averia = new HashSet<Inventario_averia>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_queja { get; set; }
        public Nullable<int> Numero_averia { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Numero_casa { get; set; }
        public string Numero_medidor { get; set; }
        public string Responsable { get; set; }
        public string Observaciones { get; set; }
        public Nullable<System.DateTime> Fecha_trabajo { get; set; }
        public Nullable<double> Costos_mano_obra { get; set; }
    
        public virtual Asada_Quejas Asada_Quejas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventario_averia> Inventario_averia { get; set; }
    }
}
