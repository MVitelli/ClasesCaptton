using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioOpcional
{
    class Cliente
    {
        private string nombreYApellido;
        private int id;
        private int cantCompras=0;
      

        public Cliente(string name, int id)
        {
            this.nombreYApellido = name;
            this.id = id;
        }
        public string GetNombre()
        {
            return this.nombreYApellido;
        }
        public void SetNombre(string nombre)
        {
            this.nombreYApellido = nombre;
        }

        public int GetID()
        {
            return this.id;
        }
        public void SetID(int id)
        {
            this.id = id;
        }

        public int GetCantidadCompras()
        {
            return this.cantCompras;
        }
        public void SetCantidadCompras(int compras)
        {
            this.cantCompras=compras;
        }

        public bool EsClienteHabitual()
        {
            return (this.cantCompras >= 2);
        }
    }
}
