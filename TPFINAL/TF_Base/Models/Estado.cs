using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estado
    {
        public Estado()
        {
            this.Boletos = new HashSet<Boletos>();
        }
    
        public int idEstado { get; set; }
        public string nombreEstado { get; set; }
    
        public virtual ICollection<Boletos> Boletos { get; set; }
    }
}
