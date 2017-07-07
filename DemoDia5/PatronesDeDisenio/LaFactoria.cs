using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDisenio
{
    class LaFactoria : IPerreable
    {
        public Perro CriarDogui(string tamaño)
        {
            Perro per = null;
            switch (tamaño.ToLower())
            {
                case "grande":
                    per = new Pitbull();
                    break;
                case "mediano":
                    per = new Labrador();
                    break;
                case "chico":
                    per = new Caniche();
                    break;
            }
            return per;
        }
    }
}
