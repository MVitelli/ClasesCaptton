using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boletos
    {
        public int numeroVuelo { get; set; }
        public int dni { get; set; }
        public int idEstado { get; set; }
        public int idBoleto { get; set; }
        public string infoBoleto { get { return this.Vuelos.fechaParaMostrar + " " + this.Vuelos.Conexiones.Aerolineas.Nombre + " | " + this.Vuelos.Conexiones.CiudadOrigen + " " + this.Vuelos.Conexiones.HorarioSalida + " - " + this.Vuelos.Conexiones.CiudadDestino + " " + this.Vuelos.Conexiones.HorarioLlegada; } }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Vuelos Vuelos { get; set; }
    }
}
