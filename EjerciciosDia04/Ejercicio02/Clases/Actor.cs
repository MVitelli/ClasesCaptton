using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    abstract class Actor
    {
        protected int id;
        protected string nombre;
        protected string apellido;
        protected int edad;
        protected int horasViajadas;

        public Actor(int id, string nombre, string apellido, int edad, int horasViajadas)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.horasViajadas = horasViajadas;
        }

        public virtual void Viajar(int horas)
        {
            this.horasViajadas += horas;
            Console.WriteLine("Usted ha viajado {0} horas", this.horasViajadas);

            this.GetPremio();
        }
        
        public abstract void GetPremio();
    }
}
