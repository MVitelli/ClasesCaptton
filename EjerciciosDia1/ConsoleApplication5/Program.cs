using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Calcula la potencia dado una base y un exponente utilizando el búcle WHILE
Calcula la potencia dado una base y un exponente utilizando el búcle FOR*/
namespace Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese base: ");
            int baseNro = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese exponente: ");
            int exponenteNro = int.Parse(Console.ReadLine());
            int i = exponenteNro;
            long resultado = 1;
            while (i > 0)
            {
                resultado = resultado * baseNro;
                i--;
            }
            long resultado2 = 1;
            for (int j = 0; j < exponenteNro; j++)
            {
                resultado2 = resultado2 * baseNro;
            }
            Console.WriteLine("resultado calculado con WHILE {0} y resultado con FOR {1}", resultado, resultado2);
            Console.ReadLine();
        }
    }
}
