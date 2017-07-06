using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaceYPoli
{
    class Perro : Animal,IPaseable
    {
        public Perro(string name)
            : base(name)
        {
 
        }

        public string Pasear(string lugar)
        {
            return this.nombre + " esta paseando por " + lugar;
        }
    }
}
