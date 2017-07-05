using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPersona
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese edad: ");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese sexo: (M o F) ");
            char sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese peso: ");
            float peso = float.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese altura: ");
            float altura = float.Parse(Console.ReadLine());

            Persona persona1 = new Persona(nombre, edad, sexo, peso, altura);
            Persona persona2 = new Persona(nombre, edad, sexo);
            Persona persona3 = new Persona();
            persona3.SetPeso(74.1F);
            persona3.SetAltura(1.89F);

            int numero = persona1.CalcularIMC();
            switch (numero)
            {
                case 1:
                    Console.WriteLine("La persona {0} tiene sobrepeso", persona1.GetNombre());
                    break;
                case 0:
                    Console.WriteLine("La persona {0} esta en su peso ideal", persona1.GetNombre());
                    break;
                case -1:
                    Console.WriteLine("La persona {0} esta por debajo de su peso ideal", persona1.GetNombre());
                    break;
            }

            Console.WriteLine("La persona {0} es mayor de edad? {1} ", persona1.GetNombre(), persona1.EsMayorDeEdad() ? "si" : "no");
            persona1.ToString();
            persona2.ToString();
            persona3.ToString();
            Console.ReadLine();

        }
    }
}
