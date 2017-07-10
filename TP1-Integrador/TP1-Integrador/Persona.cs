using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
*
*
* Trabajo Practico Integrador - Semana 1
* Vitelli, Maximiliano 
*
*
*/
namespace TP1_Integrador
{
    class Persona
    {
        private int id;
        private string nombre;

        public Persona(int id, string name)
        {
            this.id = id;
            this.nombre = name;
        }
        public string GetNombre()
        {
            return this.nombre;
        }
    }


}
