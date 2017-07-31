using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Boletos = new HashSet<Boletos>();
        }
    
        public Nullable<int> idUsuario { get; set; }
               
        [Display(Name = "DNI del cliente")]
        [Required(ErrorMessage = "El DNI es necesario")]
        [Range(200000,50000000)]
        public int dni { get; set; }
   
        public virtual ICollection<Boletos> Boletos { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
