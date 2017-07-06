using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia4
{
    class Actor : Persona
    {
        public Actor(string name, string lastname, int dni)
            : base(name, lastname, dni)
        { 
            
        }

        public override void Hablar()
        {
            Console.WriteLine(this.nombre + ": How u doin?");
        }

        public override string Comer()
        {
            return this.nombre + " doesn't share food!";
        }
    }
}
