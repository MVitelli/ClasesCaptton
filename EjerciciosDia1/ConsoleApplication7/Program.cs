using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Declarar un array tamaño 10 y completarlo con valores contiguos empezando por un numero ingresado por consola.
 * Imprimir en pantalla el contenido del array por cada una de sus posiciones*/
namespace Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumeros = new int[10];
            Console.WriteLine("Ingrese un numero: ");
            int numero = int.Parse(Console.ReadLine());
            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                arrayNumeros[i] = numero;
                numero++;
            }
            Console.Write("[ ");
            for (int j = 0; j < arrayNumeros.Length; j++)
            {
                Console.Write(arrayNumeros[j] + " ");
            }
            Console.Write("]");
            Console.ReadLine();
        }
    }
}
