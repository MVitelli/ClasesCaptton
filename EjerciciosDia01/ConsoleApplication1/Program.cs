using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Pedir el ingreso de un número del 0 al 9 por consola e imprimir el nombre en letras del mismo.
             * EJ:Ingresamos 2 por consola y la misma nos responde con el mensaje Dos*/
            Console.WriteLine("Ingrese un numero del 0 al 3");
            int numero = int.Parse(Console.ReadLine());
            switch (numero)
            {
                case 0:
                    Console.WriteLine("Cero");
                    break;
                case 1:
                    Console.WriteLine("Uno");
                    break;
                case 2:
                    Console.WriteLine("Dos");
                    break;
                default:
                    Console.WriteLine("Tres");
                    break;
            }
            Console.ReadLine();
        }
    }
}
