using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ejercicio1: Pedir al usuario que ingrese su nombre y su edad, guardando ambos valores en variables.
            Mostrar un mensaje de bienvenida que contenga ambos valores.*/
            Console.WriteLine("Ingrese su nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su edad: ");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("El usuario {0} tiene {1} años", nombre, edad);
            Console.ReadLine();
        }
    }
}
