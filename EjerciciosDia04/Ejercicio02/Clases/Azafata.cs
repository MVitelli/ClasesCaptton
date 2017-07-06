using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Azafata : Actor
    {
        const int HORAS_VUELO = 50;
        public Azafata(int id, string nombre, string apellido, int edad, int horasViajadas)
            : base(id, nombre, apellido, edad, horasViajadas)
        { 
        
        }

        public override void GetPremio()
        {
            if (HORAS_VUELO<this.horasViajadas)
            {
                Console.WriteLine("Felicitaciones {0}, has llegado/superado las 50 horas, tiene un bonus del 20% de su sueldo", this.nombre);
            }
            else
            {
                Console.WriteLine("Aun te faltan {0} de horas para el premio", HORAS_VUELO - this.horasViajadas);
            }
        }
    }
}
