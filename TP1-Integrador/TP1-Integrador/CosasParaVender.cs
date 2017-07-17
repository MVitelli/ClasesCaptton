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
    abstract class CosasParaVender
    {
        private string nombre;
        private int id;
        private float precio;

        public CosasParaVender(int id, float precio,string nombre)
        {
            this.id = id;
            this.precio = precio;
            this.nombre = nombre;
        }

        public int GetId()
        {
            return this.id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public string GetNombre()
        {
            return this.nombre;
        }
        public float GetPrecio()
        {
            return this.precio;
        }
        abstract public void Mostrar();
        
    }
}
