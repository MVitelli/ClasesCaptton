using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPersona
{
    class Persona
    {
        private string nombre;
        private int edad;
        private int dni;
        private char sexo;
        private float peso;
        private float altura;

        //constructor por defecto
        public Persona()
        {
            this.nombre = "";
            this.edad = 0;
            this.sexo = 'H';
            this.peso = 0F;
            this.altura = 0F;
            GeneraDni();
        }

        //constructor con nombre, edad y sexo
        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = 0F;
            this.altura = 0F;
            GeneraDni();
        }

        //constructor con todos los parametros
        public Persona(string nombre, int edad, char sexo, float peso, float altura, int dni)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
            this.dni = dni;
        }

        public Persona(string nombre, int edad, char sexo, float peso, float altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
            GeneraDni();
        }

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public int GetEdad()
        {
            return this.edad;
        }
        public void SetEdad(int edad)
        {
            this.edad = edad;
        }

        public int GetDni()
        {
            return this.dni;
        }
        public void SetDni(int dni)
        {
            this.dni = dni;
        }

        public char GetSexo()
        {
            return this.sexo;
        }
        public void SetSexo(char sexo)
        {
            this.sexo = sexo;
        }

        public float GetPeso()
        {
            return this.peso;
        }
        public void SetPeso(float peso)
        {
            this.peso = peso;
        }

        public float GetAltura()
        {
            return this.altura;
        }
        public void SetAltura(float altura)
        {
            this.altura = altura;
        }

        public int CalcularIMC()
        {
            float imc = 0;
            imc = this.peso / (this.altura * this.altura);
            if (imc > 25)
                return 1;
            else
            {
                if (imc == 25)
                    return 0;
                else
                    return -1;
            }
        }

        public bool EsMayorDeEdad()
        {
            return this.edad >= 18;
        }

        public void ToString()
        {
            Console.WriteLine("Nombre: {0} Edad: {1} Sexo: {2} DNI: {3} Peso: {4} Altura: {5}", GetNombre(), GetEdad(), GetSexo(), GetDni(), GetPeso(), GetAltura());
        }

        public void GeneraDni()
        {
            Random rnd = new Random();
            this.dni = rnd.Next(0, 99999999);
        }
    }
}
