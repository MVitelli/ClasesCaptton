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
    class Cliente : Persona
    {
        private bool estaHabilitado;

        public Cliente(int id, string nombre)
            : base(id, nombre)
        {
            estaHabilitado = true;
        }

        public void SetEstaHabilitado(bool valor)
        {
            this.estaHabilitado = valor;
        }
        public bool GetEstaHabilitado()
        {
            return this.estaHabilitado;
        }
    }
}
