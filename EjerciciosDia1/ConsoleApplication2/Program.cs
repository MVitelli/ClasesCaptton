using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una palabra o frase: ");
            string frase = Console.ReadLine();
            frase = frase.Replace(" ", "").ToLower();
            int i = 0;
            int j = frase.Length -1;
            Boolean esPalindromo = true;
            while (i < j && esPalindromo)
            {
                if (frase[i] == frase[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    esPalindromo = false;
                }
            }
            if (esPalindromo)
                Console.WriteLine(frase + " es palindromo");
            else
                Console.WriteLine(frase + " no es palindromo");

            Console.ReadLine();
        }

    }
}
