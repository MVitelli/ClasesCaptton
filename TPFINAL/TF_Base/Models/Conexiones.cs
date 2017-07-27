using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Conexiones
    {
        public Conexiones()
        {
            this.Vuelos = new HashSet<Vuelos>();
        }

        public string AerolineaID { get; set; }
        public int ConexionID { get; set; }
        public string CiudadOrigen { get; set; }
        public string PaisOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public string PaisDestino { get; set; }
        public System.TimeSpan HorarioSalida { get; set; }
        public System.TimeSpan HorarioLlegada { get; set; }
        public string infoConexion { get { return this.HorarioSalida+ " " +this.CiudadOrigen + "- " + this.HorarioLlegada+" "+ this.CiudadDestino; }}
        public string infoConexionConAerolinea { get { return this.Aerolineas.Nombre +" | "+ this.HorarioSalida + " " + this.CiudadOrigen + "- " + this.HorarioLlegada + " " + this.CiudadDestino; } }
        public virtual Aerolineas Aerolineas { get; set; }
        public virtual ICollection<Vuelos> Vuelos { get; set; }
    }
}
