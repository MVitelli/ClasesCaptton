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
            Calculadora.resta(6, 2);
            Calculadora.suma(2.1F, 3.5F,5.0F, 4.2F);
            Calculadora.division(4,2);
            Calculadora.multiplicacion(2,3,7);
            Console.ReadLine();
        }
    }
}
