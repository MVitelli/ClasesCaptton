using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco bancoRio = new Banco("Banco Rio");

            Cliente cliente = new Cliente("maxi");
            CuentaBancaria cuentaDeMaxi = new CuentaBancaria(cliente, 26474253);

            Cliente cliente2 = new Cliente("Juan Domingo");
            CuentaBancaria cuentaPanama = new CuentaBancaria(cliente2, 58684345);
            
            bancoRio.añadirCuentaBancaria(cuentaDeMaxi);
            bancoRio.añadirCuentaBancaria(cuentaPanama);

            //Console.WriteLine(bancoRio.hablanCuentas());

            StringBuilder str = new StringBuilder();

            foreach (CuentaBancaria item in bancoRio.listaDeCuentasBancarias)
            {
                str.AppendLine( item.getCliente().GetNombre() + ": mi cuenta es " + item.getTarjeta().GetCuenta() );
            }

            Console.WriteLine(str.ToString());


            Console.ReadKey();
        }  
    }
}
