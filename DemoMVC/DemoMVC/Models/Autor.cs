//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autor
    {
        public Autor()
        {
            this.Libro = new HashSet<Libro>();
        }
    
        public int idAutor { get; set; }
        public string nombre { get; set; }
        public string nacionalidad { get; set; }
    
        public virtual ICollection<Libro> Libro { get; set; }
    }
}
