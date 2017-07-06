using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioOpcional
{
    class Producto
    {
        private int stock;
        private string nombreProducto;
        private float precio;
        private int id;

        public Producto(string nombre, int stock, float precio,int id)
        {
            this.stock = stock;
            this.nombreProducto = nombre;
            this.precio = precio;
            this.id = id;
        }

        public int GetStock()
        {
            return this.stock;
        }
        public void SetStock(int stock)
        {
            this.stock = stock;
        }

        public string GetNombre()
        {
            return this.nombreProducto;
        }
        public void SetNombre(string nombre)
        {
            this.nombreProducto = nombre;
        }

        public float GetPrecio()
        {
            return this.precio;
        }
        public void SetPrecio(float precio)
        {
            this.precio = precio;
        }

        public int GetID()
        {
            return this.id;
        }
        public void SetID(int id)
        {
            this.id = id;
        }
    }
}
