//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstacionamientoMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class registros
    {
        public string patente { get; set; }
        public int idParcela { get; set; }
        public System.DateTime fechaIngreso { get; set; }
        public Nullable<System.DateTime> fechaEgreso { get; set; }
        public Nullable<double> monto { get; set; }
    
        public virtual parcela parcela { get; set; }
        public virtual vehiculo vehiculo { get; set; }
    }
}
