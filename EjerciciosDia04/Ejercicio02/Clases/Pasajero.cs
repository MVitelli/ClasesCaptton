using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Pasajero : Actor
    {
        bool esFrecuente;
        const int HORAS_VUELO = 100;
        public Pasajero(int id, string nombre, string apellido, int edad, int horasViajadas, bool esFrecuente)
            : base(id, nombre, apellido, edad, horasViajadas)
        {
            this.esFrecuente = esFrecuente;
        }

        public override void GetPremio()
        {
            if (horasViajadas > HORAS_VUELO && this.esFrecuente)
            {
                Console.WriteLine("Felicitaciones {0} usted ha llegado/superado las 100 horas y al ser frecuente se le regala un pasaje a Miami", this.nombre);
            }
            else if (horasViajadas > HORAS_VUELO && !this.esFrecuente)
            {
                Console.WriteLine("Felicitaciones usted ha llegado/superado las 100 horas se le regala un pasaje a Brasil");
            }
            else
            {
                Console.WriteLine("Aun te faltan {0} horas para el premio", HORAS_VUELO - horasViajadas);
            }
        }
    }
}
