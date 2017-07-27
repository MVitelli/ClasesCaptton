using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleados
    {
        public int idEmpleado { get; set; }
        public int idUsuario { get; set; }
        public string AerolineaID { get; set; }
        public bool esEncargado { get; set; }
    
        public virtual Aerolineas Aerolineas { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
