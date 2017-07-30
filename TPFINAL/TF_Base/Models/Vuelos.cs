using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vuelos
    {
        public Vuelos()
        {
            this.Boletos = new HashSet<Boletos>();
        }
    
        public string AerolineaID { get; set; }
        public int ConexionID { get; set; }
        public int numeroVuelo { get; set; }
        public System.DateTime fecha { get; set; }
        public int asientosDisponibles { get; set; }

        [Display(Name = "Capacidad del avión")]
        [Required(ErrorMessage = "Un avión tiene capacidad")]
        [Range(4, 1000, ErrorMessage="La capacidad de un avion es de 4 a 1000 asientos")]
        public int capacidad { get; set; }
        public string fechaParaMostrar { get { return this.fecha.Day + "/" + this.fecha.Month + "/" + this.fecha.Year; } }
        public string infoVuelo { get {return "Fecha: "+ this.fecha.Day +"/"+this.fecha.Month+"/"+this.fecha.Year+" - Aerolinea: "+ this.AerolineaID+ " - Numero de vuelo: "+ this.numeroVuelo +" - Numero de conexion: "+ this.ConexionID +" - Ciudad origen: "+this.Conexiones.CiudadOrigen+ " - Ciudad destino: "+this.Conexiones.CiudadDestino ; } }
    
        public virtual ICollection<Boletos> Boletos { get; set; }
        public virtual Conexiones Conexiones { get; set; }
    }
}
