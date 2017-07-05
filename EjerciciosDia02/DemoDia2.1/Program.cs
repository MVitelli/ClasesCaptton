using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alu1 = new Alumno("Pepito", "Grillo", 123123);
            Alumno alu2 = new Alumno();

            alu2.nombre = "Pedro";
            alu2.apellido = "Apostol";
            alu2.SetDni(29);

            Console.WriteLine(alu1.nombre + ": " + alu1.AsistirAClases());
            Console.WriteLine(alu2.nombre + ": " + alu2.NoMeMolestes());

            Console.WriteLine("El dni de {0} es: {1}", alu2.nombre, alu2.GetDni());

            Console.WriteLine("La cantidad de alumnos es: {0}", Alumno.cantidadAlumnos);
            Console.ReadLine();
        }
    }
}
