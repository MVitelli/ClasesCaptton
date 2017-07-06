using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    abstract class Persona
    {
        protected string nombre, apellido;
        protected int dni;

        public Persona(string name, string lastname, int dni)
        {
            this.nombre = name;
            this.apellido = lastname;
            this.dni = dni;
        }
    }
}
