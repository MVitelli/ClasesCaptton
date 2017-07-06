using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioOpcional
{
    class Empresa
    {
        private string nombre;
        private List<Producto> listaProductos = new List<Producto>();

        public Empresa(string nombre)
        {
            this.nombre = nombre;
        }

        public void AniadirProducto(Producto producto)
        {
            this.listaProductos.Add(producto);
        }

        public void Vender(Producto producto, Cliente cliente)
        {
            foreach (Producto item in listaProductos)
            {
                if (item.GetID() == producto.GetID())
                {
                    if (cliente.EsClienteHabitual())
                    {
                        item.SetStock(item.GetStock() - 1);
                        cliente.SetCantidadCompras(cliente.GetCantidadCompras() + 1);
                        Console.WriteLine("Del producto {0} se vendio 1 unidad y quedan en stock {1} unidades", item.GetNombre(), item.GetStock());
                        Console.WriteLine("Al cliente {0} por un monto de ${1}", cliente.GetNombre(), (item.GetPrecio() * 95) / 100);
                        Console.WriteLine("Es cliente habitual y tiene {0} compras", cliente.GetCantidadCompras());

                    }
                    else
                    {
                        item.SetStock(item.GetStock() - 1);
                        cliente.SetCantidadCompras(cliente.GetCantidadCompras() + 1);
                        Console.WriteLine("Del producto {0} se vendio 1 unidad y quedan en stock {1} unidades", item.GetNombre(), item.GetStock());
                        Console.WriteLine("Al cliente {0} por un monto de ${1}", cliente.GetNombre(), item.GetPrecio());
                        Console.WriteLine("No es cliente habitual tiene {0} compras", cliente.GetCantidadCompras());

                    }
                }
            }
        }

        public void Vender(Producto producto, int cantidad, Cliente cliente)
        {
            foreach (Producto item in listaProductos)
            {
                if (item.GetID() == producto.GetID())
                {
                    if (item.GetStock()>cantidad)
                    {
                        if (cliente.EsClienteHabitual())
                        {
                            item.SetStock(item.GetStock() - cantidad);
                            cliente.SetCantidadCompras(cliente.GetCantidadCompras() + cantidad);
                            Console.WriteLine("Del producto {0} se vendieron {1} unidades y quedan en stock {2} unidades", item.GetNombre(), cantidad, item.GetStock());
                            Console.WriteLine("Al cliente {0} por un monto de ${1}", cliente.GetNombre(), ((item.GetPrecio() * 95) / 100)*cantidad);
                            Console.WriteLine("Es cliente habitual y tiene {0} compras", cliente.GetCantidadCompras());

                        }
                        else
                        {
                            item.SetStock(item.GetStock() - cantidad);
                            cliente.SetCantidadCompras(cliente.GetCantidadCompras() + cantidad);
                            Console.WriteLine("Del producto {0} se vendieron {1} unidades y quedan en stock {2} unidades", item.GetNombre(),cantidad, item.GetStock());
                            Console.WriteLine("Al cliente {0} por un monto de ${1}", cliente.GetNombre(), item.GetPrecio()*cantidad);
                            Console.WriteLine("No es cliente habitual tiene {0} compras", cliente.GetCantidadCompras());

                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo se pude completar la compra. Hay stock de {0} unidades y usted solicito {1}.", item.GetStock(), cantidad);
                    }
                }
            }
        }

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
