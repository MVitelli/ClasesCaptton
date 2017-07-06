using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio01
{
    class Curso
    {
        public string nombre;
        public int nroAula;
        public List<Profesor> listaDeProfesores = new List<Profesor>(); 
        public List<Alumno> listaDeAlumnos = new List<Alumno>();

        public Curso(string nombre, int aula, Profesor profesor)
        {
            this.listaDeProfesores.Add(profesor);
            this.nombre = nombre;
            this.nroAula = aula;
        }

        public void AñadirProfesor(Profesor profesor)
        {
            listaDeProfesores.Add(profesor);
        }
        public void AñadirAlumno(Alumno alumno)
        {
            listaDeAlumnos.Add(alumno);
        }

        public string HablanAlumnos()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("En el curso: " + this.nombre);

            foreach (Profesor item in listaDeProfesores)
            {
                str.AppendLine(item.GetNombre() + ": Soy el profesor titular");
            }
            
            foreach (Alumno item in listaDeAlumnos)
            {
                str.AppendLine(item.HablaAlumno());
            }

            return str.ToString();
        }
    }
}
