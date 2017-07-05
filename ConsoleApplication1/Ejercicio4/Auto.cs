using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Auto
    {
        private string patente;
        private string marca;
        private int anio;

        public string GetPatente()
        {
            return this.patente;
        }
        public void SetPatente(string patente)
        {
            this.patente = patente;
        }
        public string GetMarca()
        {
            return this.marca;
        }
        public void SetMarca(string marca)
        {
            this.marca = marca;
        }
        public int GetAnio()
        {
            return this.anio;
        }
        public void SetAnio(int anio)
        {
            this.anio = anio;
        }
    }
}
