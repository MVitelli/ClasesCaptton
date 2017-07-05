using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCafetera
{
    class Cafetera
    {
        private int capacidadMaxima;
        private int capacidadActual;
        
        //Constructor predeterminado
        public Cafetera()
        {
            this.capacidadMaxima = 1000;
            this.capacidadActual = 0;
        }

        //Constructor con capacidad maxima
        public Cafetera(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
            this.capacidadActual = capacidadMaxima;
        }

        //Constructor con capacidad maxima y capacidad actual
        public Cafetera(int capacidadMaxima, int capacidadActual)
        {
            this.capacidadMaxima = capacidadMaxima;
            this.capacidadActual = Math.Min(capacidadActual, capacidadMaxima);
        }

        //Getters
        public int GetCapacidadMaxima()
        {
            return this.capacidadMaxima;
        }
        public int GetCapacidadActual()
        {
            return this.capacidadActual;
        }

        //Setters
        public void SetCapacidadMaxima(int capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
        }
        public void SetCapacidadActual(int capacidadActual)
        {
            this.capacidadActual = capacidadActual;
        }

        public void LlenarCafetera()
        {
            this.capacidadActual = this.capacidadMaxima;
        }

        public void ServirTaza(int cantidad)
        {
            this.capacidadActual = Math.Max(0, capacidadActual - cantidad);
        }

        public void VaciarCafetera()
        {
            this.capacidadActual = 0;
        }

        public void AgregarCafe(int cantidad)
        {
            this.capacidadActual = Math.Min(this.capacidadMaxima, cantidad + this.capacidadActual);
        }
    }
}
