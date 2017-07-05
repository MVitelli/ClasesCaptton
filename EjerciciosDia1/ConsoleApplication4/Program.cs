using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Pedir el ingreso de dos números por consola e 
             * imprimir el de menor valor primero y el de mayor valor despues, separados por una coma*/
            Console.WriteLine("Ingrese primer numero: ");
            int numero1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese segundo numero: ");
            int numero2 = int.Parse(Console.ReadLine());
            int mayor = 0;
            int menor = 0;
            if (numero1 > numero2)
            {
                mayor = numero1;
                menor = numero2;
            }
            else
            {
                mayor = numero2;
                menor = numero1;
            }
            Console.WriteLine("{0} , {1}",menor,mayor);
            Console.ReadLine();
        }
    }
}
