using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Persona
/// </summary>
public class Persona
{
    private string nombre;

    public Persona(string name)
    {
        this.nombre = name;
    }

    //PROPIEDAD (ES UN SET Y GET DE VARIABLES O ATRIBUTOS)
    public string Nombre
    {
        get
        {
            return this.nombre;
        }
        set
        {
            this.nombre = value; //value es una variable definida en una libreria
        }
    }
}