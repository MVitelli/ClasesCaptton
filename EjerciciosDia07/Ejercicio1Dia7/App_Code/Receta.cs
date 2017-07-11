using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Receta
/// </summary>
public class Receta
{
    public string titulo, instrucciones;
    public List<string> listaIngredientes;

    public Receta(string titulo, string ingrediente1, string ingrediente2, string ingrediente3, string instrucciones)
    {
        this.titulo = titulo;
        this.instrucciones = instrucciones;
        this.listaIngredientes = new List<string>();
        listaIngredientes.Add(ingrediente1);
        listaIngredientes.Add(ingrediente2);
        listaIngredientes.Add(ingrediente3);

    }
}