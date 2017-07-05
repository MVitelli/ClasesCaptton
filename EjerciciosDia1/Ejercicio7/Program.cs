using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*A partir de un array de elementos, buscar si un valor se encuentra dentro del mismo. 
 * En caso que se encuentre, mostrar la posición en la cual fue encontrado. De lo contrario, mostrar -1*/
namespace Ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumeros = { 5, 4, 3, 8, 7, 2 };
            Console.WriteLine("[");
            for (int m = 0; m < arrayNumeros.Length; m++)
            {
                Console.Write(" " + arrayNumeros[m] + " ");
            }
            Console.WriteLine("]");
            Console.WriteLine("Ingrese numero a buscar: ");
            int numero = int.Parse(Console.ReadLine());
            int i = 0;
            while (i < arrayNumeros.Length-1 && arrayNumeros[i] != numero)
            {
                i++;
            }
            if (arrayNumeros[i] == numero)
            {
                i = i + 1;
                Console.WriteLine("El numero esta en la posicion: " + i);
            }
            else
                Console.WriteLine("-1");
            Console.ReadLine();
        }
    }
}
