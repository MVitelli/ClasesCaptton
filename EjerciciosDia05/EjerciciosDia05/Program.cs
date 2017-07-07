using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosDia05
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculadora calculadora1 = Calculadora.GetInstancia();
            Calculadora calculadora2 = Calculadora.GetInstancia();

            calculadora1.Sumar(4);
            calculadora2.Sumar(10);
            calculadora1.Restar(5);
            calculadora1.PonerEnCero();
            calculadora2.MostrarNroAcumulado();
            calculadora1.MostrarNroAcumulado();
            calculadora1.Restar(5);


            Console.ReadLine();
        }
    }
}
