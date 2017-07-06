using Ejercicio01.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Declarar una clase 'Empleado' que derive de persona. La clase 'Empleado' deberá añadir los siguientes atributos:
salarioHora
horasTrabajadas
Adicionalmente, la clase 'Empleado' deberá implementar la interfaz 'Cobrador'.*/
namespace Ejercicio01
{
    class Empleado : Persona, ICobradorable
    {
        public float salarioHora;
        public int horasTrabajadas;
        public List<Factura> listaFacturas=new List<Factura>();

        public Empleado(string name, string lastname, int dni, float salarioHora, int horas)
            : base(name, lastname, dni)
        {
            this.salarioHora = salarioHora;
            this.horasTrabajadas = horas;
        }

        public void EmitirFactura(int mes)
        {
            StringBuilder str = new StringBuilder();
            foreach (Factura item in listaFacturas)
            {
                if (item.mes == mes)
                {
                    str.AppendLine("Emitiendo factura del mes " + item.mes + " con un monto total de: $" + item.montoTotal);
                }
            }
            Console.WriteLine(str.ToString());
        }
        
        public void CalcularMontoFacturar(int mes)
        {
            listaFacturas.Add(new Factura (mes, salarioHora * horasTrabajadas));
        }

        public void CambiarSalarioA(float nuevoSalario)
        {
            this.salarioHora = nuevoSalario;
        }

    }
}
