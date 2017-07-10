using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
*
*
* Trabajo Practico Integrador - Semana 1
* Vitelli, Maximiliano 
*
*
*/
namespace TP1_Integrador
{
    class MateriaPrima
    {
        private int cantDisponible;
        private string nombre;
        private Proveedor proveedor;

        public MateriaPrima(int cantDisponible, string nombre, Proveedor proveedor)
        {
            this.cantDisponible = cantDisponible;
            this.nombre = nombre;
            this.proveedor = proveedor;
        }

        public string GetNombre()
        {
            return this.nombre;
        }
        public int GetCantidad()
        {
            return this.cantDisponible;
        }
        public void SetCantidad(int cant)
        {
            this.cantDisponible = cant;
        }

        public void mostrarCantDisponible()
        {
            Console.WriteLine("La materia prima {0} tiene un stock de {1} unidades", this.nombre, this.cantDisponible);
        }


    }
}
