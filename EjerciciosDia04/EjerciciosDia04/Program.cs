using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado pepe = new Empleado("Pepe", "Grillo", 123123, 130, 40);
            pepe.CalcularMontoFacturar(2);
            pepe.CambiarSalarioA(140);
            pepe.CalcularMontoFacturar(2);
            pepe.EmitirFactura(2);
            Console.ReadLine();
        }
    }
}
