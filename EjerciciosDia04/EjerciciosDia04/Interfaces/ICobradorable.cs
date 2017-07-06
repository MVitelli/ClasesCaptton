using Ejercicio01.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Crear una interfaz de nombre 'Cobrador'. Esta es la clase que será usada por el departamento de finanzas para emitir pagos. 
 * Dicha interfaz deberá contener las siguientes funciones:
emitirFactura
calcularMontoFacturar*/
namespace Ejercicio01
{
    interface ICobradorable
    {
        void EmitirFactura(int mes);
        void CalcularMontoFacturar(int mes);
    }
}
