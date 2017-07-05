using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCafetera
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafetera miCafetera = new Cafetera();
            miCafetera.AgregarCafe(100);
            miCafetera.ServirTaza(40);
            Console.WriteLine("Capacidad maxima: {0} Capacidad actual: {1}", miCafetera.GetCapacidadMaxima(), miCafetera.GetCapacidadActual()); 
            miCafetera.LlenarCafetera();
            miCafetera.ServirTaza(15);
            miCafetera.AgregarCafe(30);
            Console.WriteLine("Capacidad maxima: {0} Capacidad actual: {1}", miCafetera.GetCapacidadMaxima(), miCafetera.GetCapacidadActual());
            miCafetera.ServirTaza(3);
            Console.WriteLine("Capacidad maxima: {0} Capacidad actual: {1}", miCafetera.GetCapacidadMaxima(), miCafetera.GetCapacidadActual());
            Console.ReadLine();
        }
    }
}
