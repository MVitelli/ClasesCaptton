using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia3
{
    class Proyecto
    {
        public string nombre;
        public bool exito;

        public Proyecto(string name)
        {
            this.nombre = name;
            this.exito = false;
        }

        public bool EsExitoso(Supervisor sup)
        {
            if (sup.listaEmpleadosACargo.Count <= 2)
            {
                this.exito = true;
            }
            return this.exito;
        }
    }
}
