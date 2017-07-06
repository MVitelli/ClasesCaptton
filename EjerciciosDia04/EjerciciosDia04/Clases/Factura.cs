using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01.Clases
{
    class Factura
    {
        public int mes;
        public float montoTotal;

        public Factura(int mes, float montoTotal)
        {
            this.mes = mes;
            this.montoTotal = montoTotal;

        }
    }
}
