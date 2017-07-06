using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {

            Universidad utn = new Universidad("UTN");
            Profesor dodain = new Profesor("Dodain");
            Profesor bender = new Profesor("Bender");
            Profesor juan = new Profesor("Juan");
            Curso sintaxis = new Curso("Sintaxis y semantica", 250, bender);
            Curso paradigmas = new Curso("Paradigmas de programacion", 283, dodain);
            Alumno alum1 = new Alumno("Maxi", utn);
            Alumno alum2 = new Alumno("Pepito", utn);
            Alumno alum3 = new Alumno("Peron", utn);

            utn.AñadirCurso(paradigmas);

            paradigmas.AñadirProfesor(juan);   
            paradigmas.AñadirAlumno(alum1);
            paradigmas.AñadirAlumno(alum2);
            paradigmas.AñadirAlumno(alum3);

            utn.AñadirCurso(sintaxis);

            sintaxis.AñadirAlumno(alum1);


            Console.WriteLine(utn.HablanCursos());

            Console.ReadKey();
        }
    }
}
