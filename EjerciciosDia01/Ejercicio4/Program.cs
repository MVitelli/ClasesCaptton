using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Declarar un array de 5 posiciones de texto y luego inicializarlo.
Recorrerlo imprimiendo por pantalla cada uno de los valores contenidos
Declarar un array de 5 posiciones numéricas e inicializarlo en la misma linea.
Recorrerlo e imprimir sólo los números contenidos que sean pares*/
namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayTexto = { "hola", "como", "te", "va", "?" };
            int[] arrayNumeros = {3,2,8,4,15};
            for (int i = 0; i < arrayTexto.Length; i++)
            {
                Console.Write(arrayTexto[i] + " ");
            }
            for (int j = 0; j < arrayNumeros.Length; j++)
            {
                if (arrayNumeros[j] % 2 == 0)
                    Console.Write(arrayNumeros[j] + " ");
            }
            Console.ReadLine();
        }
    }
}
