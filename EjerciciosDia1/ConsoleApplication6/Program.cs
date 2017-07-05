using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Partiendo de un array de números declarado dentro del código, calcular el promedio y mostrarlo por consola. 
Recodemos, la formula del promedio : (A1+...An) / n*/

namespace Ejercicio9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumeros = { 2, 4, 5, 8, 15, 7 };
            int suma = 0;
            int i;
            for (i=0; i < arrayNumeros.Length; i++)
            {
                suma = suma + arrayNumeros[i];
            }
            Console.WriteLine("El promedio es {0}", suma / i);
            Console.ReadLine();
        }
    }
}
