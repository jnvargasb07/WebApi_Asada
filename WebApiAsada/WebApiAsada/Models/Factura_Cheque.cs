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
    
    public partial class Factura_Cheque
    {
        public int ID { get; set; }
        public Nullable<int> ID_cheque { get; set; }
        public Nullable<int> ID_factura { get; set; }
    
        public virtual Cheques Cheques { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
