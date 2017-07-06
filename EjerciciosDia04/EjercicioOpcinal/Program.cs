using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioOpcional
{
    class Program
    {
        static void Main(string[] args)
        {
            Empresa carbarino = new Empresa("Carbarino S.A.");
            Producto pelota = new Producto("Pelota de futbol", 20, 500, 123);
            Cliente maxi = new Cliente("Maxi", 456);
            carbarino.AniadirProducto(pelota);

            carbarino.Vender(pelota, maxi);
            carbarino.Vender(pelota, maxi);
            carbarino.Vender(pelota, 15, maxi);
            carbarino.Vender(pelota, 6, maxi);

            Console.ReadLine();
        }
    }
}
