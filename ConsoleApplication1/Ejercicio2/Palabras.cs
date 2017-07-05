using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Palabra
    {
        public static bool Palindromo(string palabra)
        {
            palabra = palabra.Replace(" ", "").ToLower();
            int i = 0;
            int j = palabra.Length - 1;
            bool esPalindromo = true;
            while (i < j && esPalindromo)
            {
                if (palabra[i] == palabra[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    esPalindromo = false;
                }
            }
            return esPalindromo;
        }
    }
}