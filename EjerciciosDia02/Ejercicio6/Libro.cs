using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Crea una clase Libro que modele la información que se mantiene en una biblioteca 
 * sobre cada libro: título, autor (usa la clase Persona), ISBN, páginas, 
 * edición, editorial , lugar (ciudad y país) y fecha de edición (usa la clase Fecha). 
 * La clase debe proporcionar los siguientes servicios: accedentes y mutadores, 
 * método para leer la información y método para mostrar la información.
 */
namespace Ejercicio6
{
    class Libro
    {
        private string titulo;
        private string autor;
        private string isbn;
        private int paginas;
        private string editorial;
        private string lugar;
        private string fecha;
        
        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }
        public string GetTitulo()
        {
            return this.titulo;
        }

        public void SetAutor(string autor)
        {
            this.autor = autor;
        }
        public string GetAutor()
        {
            return this.autor;
        }

        public void SetIsbn(string isbn)
        {
            this.isbn = isbn;
        }
        public string GetIsbn()
        {
            return this.isbn;
        }

        public void SetPaginas(int paginas)
        {
            this.paginas = paginas;
        }
        public int GetPaginas()
        {
            return this.paginas;
        }

        public void SetEditorial(string editorial)
        {
            this.editorial = editorial;
        }
        public string GetEditorial()
        {
            return this.editorial;
        }

        public void SetLugar(string lugar)
        {
            this.lugar = lugar;
        }
        public string GetLugar()
        {
            return this.lugar;
        }

        public void SetFecha(string fecha)
        {
            this.fecha = fecha;

        }
        public string GetFecha()
        {
            return this.fecha;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Titulo: {0}", GetTitulo());
            Console.WriteLine("Autor: {0}", GetAutor());
            Console.WriteLine("ISBN: {0}", GetIsbn());
            Console.WriteLine(GetEditorial() + ", " + GetLugar());
            Console.WriteLine(GetFecha() + " " + GetPaginas() + " paginas.");
        }
    }
}
