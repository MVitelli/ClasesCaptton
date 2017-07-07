using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosDia05
{
    class Calculadora
    {
        private static Calculadora single;

        private int numero = 0;

        private Calculadora()
        {

        }

        public static Calculadora GetInstancia()
        {
            if (single == null)
            {
                single = new Calculadora();
            }
            return single;
        }

        public void Sumar(int num)
        {
            this.numero += num;
            Console.WriteLine("Ahora el numero es: {0}", this.numero);
        }
        public void Restar(int num)
        {
            this.numero -= num;
            Console.WriteLine("Ahora el numero es: {0}", this.numero);
        }
        public void Multiplicar(int num)
        {
            this.numero *= num;
            Console.WriteLine("Ahora el numero es: {0}", this.numero);
        }
        public void PonerEnCero()
        {
            Console.WriteLine("La calculadora estaba en: {0}", this.numero);
            this.numero = 0;
            Console.WriteLine("Ahora el numero es: {0}", this.numero);
        }
        public void MostrarNroAcumulado()
        {
            Console.WriteLine("El numero acumulado actual es: {0}", this.numero);
        }
    }
}
