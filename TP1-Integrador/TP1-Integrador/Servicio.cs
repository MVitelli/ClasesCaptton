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
    class Servicio : CosasParaVender
    {
        public Servicio(int id, float precio, string nombre)
            : base(id, precio, nombre)
        {
        }
        public override void Mostrar()
        {
            Console.WriteLine("Servicio\n nombre: {0}, ID: {1}, precio: ${2}.", this.GetNombre(), this.GetId(), this.GetPrecio());
        }
    }
}
