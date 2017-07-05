using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Desarrolle una calculadora de interes para los clientes de un banco dado por linea de comando un capital inicial, 
 * taza anual(taza por periodo) y cantidad de años(cantidad de periodos).

La formula a utilizar es:  el capital acumulado del periodo anterior + (taza * el capital acumulado)
Ejemplo:
Periodos p = 4 | Taza i = 10 % | Capital inicial c = $1000
p = 1 | capital acumulado = $1000 | interes = (capital acumulado * taza) $1000 * 0.1 = $100
p = 2 | capital acumulado = $1100 | interes = (capital acumulado * taza) $1100 * 0.1 = $110
p = 3 | capital acumulado = $1210 | interes = (capital acumulado * taza) $1210 * 0.1 = $121
p = 4 | capital acumulado = $1331 | interes = (capital acumulado * taza) $1331 * 0.1 = $133
Intereses acumulado a lo largo al final del 4 periodo $464
 */
namespace Ejercicio13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese capital inicial: ");
            int capitalInicial = int.Parse(Console.ReadLine());
            while (capitalInicial <= 0)
            {
                Console.WriteLine("Error. Ha ingresado un capital negativo.");
                Console.WriteLine("Ingrese capital inicial: ");
                capitalInicial = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Ingrese taza anual: ");
            int tazaAnual = int.Parse(Console.ReadLine());
            while (tazaAnual <= 0 || tazaAnual > 50)
            {
                Console.WriteLine("Error. Ha ingresado una taza negativa.");
                Console.WriteLine("Ingrese taza anual: ");
                tazaAnual = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Ingrese cantidad de años: ");
            int años = int.Parse(Console.ReadLine());
            while (años <= 0)
            {
                Console.WriteLine("Error. Ha ingresado una cantidad de años invalida.");
                Console.WriteLine("Ingrese cantidad de años: ");
                años = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Periodos p = {0} | Taza i = {1} | Capital inicial c = {2}", años, tazaAnual, capitalInicial);

            int i = 0;
            int capitalAcumulado = capitalInicial;
            int interes = 0;
            int interesTotal = 0;
            do
            {
                interes = capitalAcumulado * tazaAnual / 100;
                Console.WriteLine("p = {0} | capital acumulado = ${1} | interes = (capital acumulado * taza) ${1} * {2} = ${3}", i, capitalAcumulado, (float)tazaAnual / 100, interes);
                i++;
                capitalAcumulado = capitalAcumulado + interes;
                interesTotal = interesTotal + interes;
            } while (i < años);
            Console.WriteLine("Intereses acumulados a lo largo al final del {0} periodo ${1}", años, interesTotal);
            Console.ReadKey();
        }
    }
}
