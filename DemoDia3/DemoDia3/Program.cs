using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDia3
{
    class Program
    {
        static void Main(string[] args)
        {
            TarjetaIdentificacion tarj = new TarjetaIdentificacion();
            Empleado emp1 = new Empleado("Gabi");
            Empleado emp2 = new Empleado("Mario");
            Empleado emp3 = new Empleado("Matias");
            Supervisor capo = new Supervisor("Kyouma", "Psy Congroo");

            Console.WriteLine(capo.Ingresar(tarj));
            capo.AgregarEmpleado(emp1);
            capo.AgregarEmpleado(emp2);
            capo.AgregarEmpleado(emp3);

            Console.WriteLine(capo.HacerTrabajar());

            Console.WriteLine("El sueldo antes de evaluar es: {0}", capo.sueldo);
            capo.Evaluar();
            Console.WriteLine("El sueldo de {0} despues de evaluar es: {1}",capo.nombre, capo.sueldo);
            Console.ReadLine();
        }
    }
}
