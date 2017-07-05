using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Dado un valor de temperatura por consola y una unidad de medida origen y destino, convertir el valor según corresponda. 
 * Las unidades disponibles de temperatura serán: Grados Celsius, Grados Fahrenheit o Grados Kelvin. */
namespace Ejercicio12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese opcion: ");
            Console.WriteLine("1- De Celsius a Fahrenheit.");
            Console.WriteLine("2- De Celsius a Kelvin.");
            Console.WriteLine("3- De Fahrenheit a Celsius.");
            Console.WriteLine("4- De Fahrenheit a Kelvin.");
            Console.WriteLine("5- De Kelvin a Celsius.");
            Console.WriteLine("6- De Kelvin a Fahrenheit.");
            int opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese temperatura a convertir: ");
            float temperaturaInicial = float.Parse(Console.ReadLine());
            float temperaturaFinal;
            switch (opcion)
            {
                case 1: //De Celsius a Fahrenheit
                    temperaturaFinal = (float)(temperaturaInicial * 1.8 + 32.0);
                    break;
                case 2: //De Celsius a Kelvin
                    temperaturaFinal = (float)(temperaturaInicial + 273.15);
                    break;
                case 3: //De Fahrenheit a Celsius
                    temperaturaFinal = (float)((temperaturaInicial - 32) / 1.8);
                    break;
                case 4: //De Fahrenheit a Kelvin
                    temperaturaFinal = (float)((temperaturaInicial - 32) / 1.8 +273.15);
                    break;
                case 5: //De Kelvin a Celsius
                    temperaturaFinal = (float)(temperaturaInicial - 273.15);
                    break;
                default://De Kelvin a Fahrenheit
                    temperaturaFinal = (float)(1.8 * (temperaturaInicial - 273.15) + 32);
                    break;

            }
            Console.WriteLine("La temperatura convertida es: " + temperaturaFinal);
            Console.ReadLine();
        }
    }
}
