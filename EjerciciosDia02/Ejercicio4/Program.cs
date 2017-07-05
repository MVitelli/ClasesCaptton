using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto vehiculo = new Auto();
            Console.WriteLine("Ingrese la patente: ");
            vehiculo.SetPatente (Console.ReadLine());
            Console.WriteLine("Ingrese la marca: ");
            vehiculo.SetMarca(Console.ReadLine());
            Console.WriteLine("Ingrese el anio: ");
            vehiculo.SetAnio(int.Parse(Console.ReadLine()));

            Console.WriteLine("Patente: {0} Marca: {1} Anio: {2}", vehiculo.GetPatente(), vehiculo.GetMarca(), vehiculo.GetAnio());
            Console.ReadLine();
        }
    }
}
