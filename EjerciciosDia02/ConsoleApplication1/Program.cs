using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Reescribir el Ejercicio 8 de la Leccion uno utilizando una lista en vez de un vector
namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listaNumeros = new List<int> { 4, 5, 3, 2, 8, 15 };
            listaNumeros.Sort();
            foreach (int item in listaNumeros)
            {
                Console.Write(item+" ");
            }
            Console.ReadLine();
        }
    }
}
