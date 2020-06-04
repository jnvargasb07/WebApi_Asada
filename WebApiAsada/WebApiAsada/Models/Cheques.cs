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
    
    public partial class Cheques
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cheques()
        {
            this.Factura_Cheque = new HashSet<Factura_Cheque>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_cuenta_bancaria { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Numero_cheque { get; set; }
        public Nullable<int> Numero_cuenta { get; set; }
        public Nullable<double> Monto { get; set; }
        public string Portador { get; set; }
        public string Concepto { get; set; }
        public Nullable<bool> Tipo { get; set; }
        public string Cuenta_contable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura_Cheque> Factura_Cheque { get; set; }
        public virtual Cuentas_Bancarias Cuentas_Bancarias { get; set; }
    }
}