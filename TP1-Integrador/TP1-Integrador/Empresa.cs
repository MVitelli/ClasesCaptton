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
    class Empresa
    {
        private string nombre;
        List<CosasParaVender> listaCosas;
        List<Cliente> listaClientes;

        public Empresa(string nombre)
        {
            this.nombre = nombre;
            listaClientes = new List<Cliente>();
            listaCosas = new List<CosasParaVender>();
        }

        public void AgregarManufactura(Manufactura manufactura)
        {
            this.listaCosas.Add(manufactura);
        }
        public void AgregarServicio(Servicio servicio)
        {
            this.listaCosas.Add(servicio);
        }
        public void AgregarCliente(Cliente cliente)
        {
            this.listaClientes.Add(cliente);
        }
        public void FabricarManufactura(CosasParaVender cosa, int cantidad)
        {

            foreach (CosasParaVender item in listaCosas)
            {
                if (item is Manufactura)
                {
                    Manufactura manu = (Manufactura)item;
                    if (manu.GetId() == cosa.GetId())
                    {
                        if (manu.GetMatPrima().GetCantidad() - cantidad > 0)
                        {
                            manu.SetStock(manu.GetStock() + cantidad);
                            manu.GetMatPrima().SetCantidad(manu.GetMatPrima().GetCantidad() - cantidad);
                            Console.WriteLine("Se fabricaron {0} unidades de {1}. Me quedan {2} unidades de {3} para usar.", cantidad, item.GetNombre(), manu.GetMatPrima().GetCantidad(), manu.GetMatPrima().GetNombre());
                            Console.WriteLine("------------------------------------------------------------");
                        }
                    }
                }
            }
        }


        public void Vender(CosasParaVender loQueSea, int cantidad, Cliente cliente)
        {
            if (cliente.GetEstaHabilitado())
            {
                foreach (CosasParaVender item in listaCosas)
                {
                    if (loQueSea.GetId() == item.GetId())
                    {
                        if (item is Manufactura)
                        {
                            Manufactura manufactura = (Manufactura)item;
                            if (manufactura.GetStock() - cantidad > 0)
                            {
                                manufactura.SetStock(manufactura.GetStock() - cantidad);
                                float montoTotal = cantidad * manufactura.GetPrecio();
                                Console.WriteLine(cliente.GetNombre() + ", elija: 1-Consumidor final, 2-Responsable Inscripto");
                                int opcion = int.Parse(Console.ReadLine());
                                switch (opcion)
                                {
                                    case 1:
                                        Console.WriteLine("Factura B");
                                        Console.WriteLine("El cliente {0} compro {1} unidades de {2}-{3} a un precio de ${4} c/u por un monto total de ${5}", cliente.GetNombre(), cantidad, manufactura.GetId(), manufactura.GetNombre(), manufactura.GetPrecio(), montoTotal);
                                        Console.WriteLine("Quedan en stock {0} unidades de {1}", manufactura.GetStock(), manufactura.GetNombre());
                                        Console.WriteLine("------------------------------------------------------------");
                                        break;
                                    case 2:
                                        Console.WriteLine("Factura A");
                                        Console.WriteLine("El cliente {0} compro {1} unidades de {2}-{3} a un precio de ${4} c/u por un monto total de ${5}", cliente.GetNombre(), cantidad, manufactura.GetId(), manufactura.GetNombre(), manufactura.GetPrecio(), cantidad * manufactura.GetPrecio());
                                        Console.WriteLine("Neto gravado: ${0}, IVA 21%: ${1}", montoTotal / 1.21F, (montoTotal / 1.21F) * 0.21F);
                                        Console.WriteLine("Quedan en stock {0} unidades de {1}", manufactura.GetStock(), manufactura.GetNombre());
                                        Console.WriteLine("------------------------------------------------------------");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay stock suficiente del producto {0}. Nos quedan {1} unidades y usted solicito {2}.", manufactura.GetNombre(), manufactura.GetStock(), cantidad);
                            }
                        }
                        else
                        {
                            Servicio servicio = (Servicio)item;
                            float montoTotal = cantidad * servicio.GetPrecio();
                            Console.WriteLine(cliente.GetNombre() + ", elija: 1-Consumidor final, 2-Responsable Inscripto");
                            int opcion = int.Parse(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine("Factura B");
                                    Console.WriteLine("Al cliente {0} se le presto el servicio de {1}-{2} x{3} a un precio de ${4} c/u por un monto total de ${5}", cliente.GetNombre(), servicio.GetId(), servicio.GetNombre(), cantidad, servicio.GetPrecio(), montoTotal);
                                    Console.WriteLine("------------------------------------------------------------");
                                    break;
                                case 2:
                                    Console.WriteLine("Factura A");
                                    Console.WriteLine("Al cliente {0} se le presto el servicio de {1}-{2} x{3} a un precio de ${4} c/u por un monto total de ${5}", cliente.GetNombre(), servicio.GetId(), servicio.GetNombre(), cantidad, servicio.GetPrecio(), cantidad * servicio.GetPrecio());
                                    Console.WriteLine("Neto gravado: ${0}, IVA 21%: ${1}", montoTotal / 1.21F, (montoTotal / 1.21F) * 0.21F);
                                    Console.WriteLine("------------------------------------------------------------");
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("El cliente {0} no esta habilitado para comprar", cliente.GetNombre());
                Console.WriteLine("------------------------------------------------------------");
            }
        }

        public void MostrarProductosYServicios()
        {
            Console.WriteLine("Lista de Productos y Servicios\n");
            foreach (CosasParaVender item in listaCosas)
            {
                if (item is Manufactura)
                {
                    Manufactura manufactura = (Manufactura)item;
                    Console.WriteLine("Manufactura\n nombre: {0}, ID: {1}, precio: ${2}, en stock: {3} unidades", manufactura.GetNombre(), manufactura.GetId(), manufactura.GetPrecio(), manufactura.GetStock());
                }
                else
                {
                    Servicio servicio = (Servicio)item;
                    Console.WriteLine("Servicio\n nombre: {0}, ID: {1}, precio: ${2}.", servicio.GetNombre(), servicio.GetId(), servicio.GetPrecio());
                }
            }
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}

