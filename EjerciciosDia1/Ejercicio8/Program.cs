using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 5, 3, 4, 7, 9 };

            int i = 0;
            int temp;
            while (i < arreglo.Length)
            {
                int j = 0;
                while (j < arreglo.Length - 1)
                {
                    if (arreglo[j] < arreglo[j + 1])
                    {
                        temp = arreglo[j];
                        arreglo[j] = arreglo[j + 1];
                        arreglo[j + 1] = temp;
                    }
                    j++;
                }
                i++;
            }
            Console.WriteLine("[");
            for (int m = 0; m < arreglo.Length; m++)
            {
                Console.Write(" " + arreglo[m] + " ");
            }
            Console.WriteLine("]");
            Console.ReadLine();
        }
    }
}
