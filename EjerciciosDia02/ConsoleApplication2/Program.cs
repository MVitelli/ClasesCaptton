using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listaAlumnos = new List<string>();
            List<int> listaEdades = new List<int> { 25, 67, 48, 36, 15 };

            listaAlumnos.Add("Diego Milito");
            listaAlumnos.Add("Luli Aued");
            listaAlumnos.Add("Ezequiel Videla");
            listaAlumnos.Add("Agustin Orion");

            foreach (string nombre in listaAlumnos)
            {
                Console.WriteLine(nombre);
            }

            listaEdades.Sort();
            listaEdades.Reverse();

            foreach (int item in listaEdades)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
            if (listaAlumnos.Contains("Agustin Orion"))
            {
                Console.WriteLine("el elemento  esta en la posicion " + listaAlumnos.IndexOf("Agustin Orion"));
                listaAlumnos.RemoveAt(3);
            }
            foreach (string item in listaAlumnos)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
