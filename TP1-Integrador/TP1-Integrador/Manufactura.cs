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
    class Manufactura : CosasParaVender
    {
        private int stock;
        private MateriaPrima matPrima;

        public Manufactura(int stock, MateriaPrima matPrima,string nombre, int id, float precio)
            : base(id, precio,nombre)
        {
            this.stock = stock;
            this.matPrima = matPrima;
        }
        public void agregarMateriaPrima(int cantidad)
        {
            this.matPrima.SetCantidad(this.matPrima.GetCantidad() + cantidad);
        }
        public int GetStock()
        {
            return this.stock;
        }
        public void SetStock(int stock)
        {
            this.stock = stock;
        }
        public MateriaPrima GetMatPrima()
        {
            return this.matPrima;
        }
        public void SetMateriaPrima(MateriaPrima matPrima)
        {
            this.matPrima = matPrima;
        }
        public void mostrarStock()
        {
            Console.WriteLine("El producto {0} tiene un stock de {1} unidades", this.GetNombre(), this.GetStock());
        }
        public override void Mostrar()
        {
            Console.WriteLine("Manufactura\n nombre: {0}, ID: {1}, precio: ${2}, en stock: {3} unidades", this.GetNombre(), this.GetId(), this.GetPrecio(), this.GetStock());
        }
    }


}
