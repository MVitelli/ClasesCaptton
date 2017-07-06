using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia4
{
    class Alumno : Persona
    {
        public float promedio;

        public Alumno(string name, string lastname, int dni, float promedio)
            : base(name, lastname, dni)
        {
            this.promedio = promedio;
        }

        public override void Hablar()
        {
            Console.WriteLine("Hey ᕦ( ̿ ﹏ ̿ )ᕤ");
        }

        public override string Comer()
        {
            return "Iami Iami";
        }

        public override string Pensar()
        {
            return "Ah, pero el sombrero es nuevo";
        }

        public void AsistirAClases()
        {
            if (this.promedio > 6)
            {
                Console.WriteLine(this.nombre + " es un buen alumno");
            }
            else
            {
                Console.WriteLine(this.nombre + " es un fraca");
            }
        }
    }
}
