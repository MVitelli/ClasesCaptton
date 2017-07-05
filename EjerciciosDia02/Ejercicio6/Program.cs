using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Libro unLibro = new Libro();
            unLibro.SetTitulo("Introduction to Java Programming 3a. edición");
            unLibro.SetAutor("Liang, Y. Daniel");
            unLibro.SetIsbn("0-13-031997-X");
            unLibro.SetEditorial("Prentice-Hall");
            unLibro.SetLugar("New Jersey (USA)");
            unLibro.SetFecha("Viernes 16 de noviembre de 2001");
            unLibro.SetPaginas(784);

            unLibro.MostrarInformacion();
            Console.ReadLine();

        }
    }
}
