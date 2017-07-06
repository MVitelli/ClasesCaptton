using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia4
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor joey = new Actor("Joey", "Tribbiani", 2654988);
            Alumno alumno = new Alumno("Matias", "Gimenez", 34376259, 2.5F);

            joey.Hablar();
            Console.WriteLine(joey.Comer());

            alumno.AsistirAClases();
            alumno.Hablar();
            Console.ReadLine();
        }
    }
}
