using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Piloto cacho = new Piloto(456, "Cacho", "Cacho", 100, 25); 
            Azafata nami = new Azafata(123, "Nami", "Nami", 18, 15);
            Pasajero elPrimero = new Pasajero(001, "elPrimero", "soy", 2017, 50, true);
            nami.Viajar(15);
            nami.Viajar(30);
            cacho.Viajar(3);
            cacho.Viajar(10);
            elPrimero.Viajar(51);

            Console.ReadLine();

        }
    }
}
