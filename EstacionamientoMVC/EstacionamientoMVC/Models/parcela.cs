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
    
    public partial class parcela
    {
        public parcela()
        {
            this.registros = new HashSet<registros>();
        }
    
        public int idParcela { get; set; }
        public bool estado { get; set; }
    
        public virtual ICollection<registros> registros { get; set; }
    }
}