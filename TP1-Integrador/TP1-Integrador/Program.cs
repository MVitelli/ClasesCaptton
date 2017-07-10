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
    class Program
    {
        static void Main(string[] args)
        {
            Empresa carbarino = new Empresa("Carbarino S.A.");
            Cliente cliente1 = new Cliente(1, "Frodo");
            Cliente cliente2 = new Cliente(2, "Sam");
            Cliente cliente3 = new Cliente(3, "Gandalf");

            Proveedor miProveedor = new Proveedor(125, "Mi Proveedor");
            MateriaPrima alambreDeCobre = new MateriaPrima(100, "Alambre de cobre", miProveedor);
            MateriaPrima tornillosDe4mm = new MateriaPrima(500, "Tornillos de 4 mm", miProveedor);
            miProveedor.AgregarMatPrima(alambreDeCobre);
            miProveedor.AgregarMatPrima(tornillosDe4mm);

            Manufactura cargadorPortatil = new Manufactura(15, tornillosDe4mm, "Cargador Portatil", 999, 150.00F);
            Manufactura tester = new Manufactura(10, alambreDeCobre, "Tester", 998, 210.50F);

            Servicio reparacion = new Servicio(110, 100.00F, "Reparaciones varias");
            Servicio soporteTecnico = new Servicio(555, 300.00F, "Soporte tecnico");

            carbarino.AgregarCliente(cliente1);
            carbarino.AgregarCliente(cliente2);
            carbarino.AgregarCliente(cliente3);
            carbarino.AgregarManufactura(cargadorPortatil);
            carbarino.AgregarManufactura(tester);
            carbarino.AgregarServicio(reparacion);
            carbarino.AgregarServicio(soporteTecnico);

            carbarino.FabricarManufactura(tester, 80);
            tester.mostrarStock();
            alambreDeCobre.mostrarCantDisponible();

            cliente1.SetEstaHabilitado(false);

            carbarino.Vender(tester, 50, cliente1);
            carbarino.Vender(tester, 30, cliente2);
            carbarino.Vender(tester, 100, cliente2);
            carbarino.Vender(cargadorPortatil, 8, cliente3);

            carbarino.Vender(reparacion, 2, cliente2);
            carbarino.Vender(soporteTecnico, 1, cliente3);

            carbarino.MostrarProductosYServicios();

            Console.ReadLine();
        }
    }
}
