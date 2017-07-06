using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaceYPoli
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("Snowball");
            Tigre tigre = new Tigre("Richard Parker");
            Perro perro = new Perro("Huesos");

            List<Animal> listaAnimales = new List<Animal>();
            listaAnimales.Add(animal);
            listaAnimales.Add(tigre);
            listaAnimales.Add(perro);

            foreach (Animal item in listaAnimales)
            {
                if (item is Perro)
                {
                    Perro per = item as Perro; //(Perro)item;
                    Console.WriteLine(per.Pasear("Avenida Siempre Viva"));
                }
            }
            Console.ReadLine();
        }
    }
}
