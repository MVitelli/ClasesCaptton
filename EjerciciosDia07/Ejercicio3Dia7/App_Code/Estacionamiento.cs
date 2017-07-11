using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Estacionamiento
/// </summary>
public class Estacionamiento
{
    private const float PRECIO_HORA = 40F;

    public static List<Auto> listaAutos;

    public Estacionamiento()
    {
    }
    public static string Salir(string patente)
    {
        Auto autoAux = new Auto(patente, " ");
        int indice = listaAutos.IndexOf(autoAux);
        if (indice != -1)
        {
            autoAux = listaAutos.ElementAt(indice);
            DateTime tiempoActual = DateTime.Now;
            TimeSpan resultado = tiempoActual.Subtract(autoAux.horarioEntrada);
            int cantHoras = resultado.Hours;
            listaAutos.RemoveAt(indice);
            return " debe pagar un costo de estacionamiento de: $" + cantHoras * PRECIO_HORA;
        }
        else
        {
            return " no fue encontrado.";
        }
    }
}