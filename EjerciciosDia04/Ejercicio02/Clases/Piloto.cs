using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Piloto : Actor
    {
        const int HORAS_VUELO = 30;
        public Piloto(int id, string nombre, string apellido, int edad, int horasViajadas)
            : base(id, nombre, apellido, edad, horasViajadas)
        { 
        
        }

        public override void GetPremio()
        {
            if (horasViajadas>HORAS_VUELO)
            {
                Console.WriteLine("Felicitaciones {0}, has llegado/superado las 25 horas, tiene una semana de descanso", this.nombre); 
            }
            else
            {
                Console.WriteLine("Aun te faltan {0} horas para el premio", HORAS_VUELO-this.horasViajadas);
            }
        }
    }
}
