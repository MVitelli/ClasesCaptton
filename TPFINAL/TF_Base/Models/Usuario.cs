using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Cliente = new HashSet<Cliente>();
            this.Empleados = new HashSet<Empleados>();
        }
    
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
