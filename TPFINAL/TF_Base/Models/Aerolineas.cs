using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aerolineas
    {
        public Aerolineas()
        {
            this.Conexiones = new HashSet<Conexiones>();
            this.Empleados = new HashSet<Empleados>();
        }
    
        public string AerolineaID { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
        public string infoAerolinea { get { return this.AerolineaID+ " - " + this.Nombre;} }
    
        public virtual ICollection<Conexiones> Conexiones { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
