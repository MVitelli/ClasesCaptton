using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un puntaje del 0 al 9: ");
            int puntaje = int.Parse(Console.ReadLine());
            switch (puntaje)
            {
                case 1:
                case 2:
                case 3:
                    puntaje = puntaje + 10 * puntaje;
                    break;
                case 4:
                case 5:
                case 6:
                    puntaje = puntaje + 100 * puntaje;
                    break;
                case 7:
                case 8:
                case 9:
                    puntaje = puntaje + 1000 * puntaje;
                    break;
                default:
                    Console.WriteLine("Mensaje de error");
                    break;
            }
            if (puntaje != 0 && puntaje != 9)
                Console.WriteLine("Su puntaje extra es: " + puntaje);
            Console.ReadLine();
        }
    }
}
