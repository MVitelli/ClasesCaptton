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
    class Proveedor : Persona
    {
        List<MateriaPrima> listaMateriaPrima;

        public Proveedor(int id, string nombre)
            : base(id, nombre)
        {
            listaMateriaPrima = new List<MateriaPrima>();
        }
        public void AgregarMatPrima(MateriaPrima matPrima)
        {
            this.listaMateriaPrima.Add(matPrima);
        }
    }
}
