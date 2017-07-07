using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDisenio
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton single1 = Singleton.GetInstancia();
            Singleton single2 = Singleton.GetInstancia();
            Singleton single3 = Singleton.GetInstancia();
            Singleton single4 = Singleton.GetInstancia();

            Console.WriteLine(single4.cantidadDeInstancias);
            Console.ReadLine();

            LaFactoria factory = new LaFactoria();
            Perro per = factory.CriarDogui("grande");
        }
    }
}
