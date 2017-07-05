using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Convertir el Ejercicio 11 de la Leccion uno en un método e invocarlo utilizando distintas palabras 
y frases desde el código. Mostrar por consola el resultado de las llamadas*/
namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                string palabra; 
                Console.WriteLine("Ingrese palabra: ");
                palabra = Console.ReadLine();
                Console.WriteLine(Palabra.Palindromo(palabra) ? "es palindromo" : "NO es palindromo");
            }
        }
    }
}
