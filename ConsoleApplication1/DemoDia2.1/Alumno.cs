using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia2._1
{
    class Alumno
    {
        //ATRIBUTOS
        public string nombre, apellido;
        private int dni;
        public static int cantidadAlumnos;
        
        //CONSTRUCTOR POR DEFECTO
        public Alumno()
        {
            cantidadAlumnos++;
        }

        //OTRO CONSTRUCTOR
        public Alumno(string name, string lastname, int dni)
        {
            this.nombre = name;
            this.apellido = lastname;
            this.dni = dni;
            cantidadAlumnos++;
        }

        public int GetDni()
        {
            return this.dni;
        }
        public void SetDni(int dni)
        {
            this.dni = dni;
        }
        public string AsistirAClases()
        {
            return "Hoy tuve clases de Anatomia, grr";
        }
        public string NoMeMolestes()
        {
            return "A quien le importa?";
        }
    }
}
