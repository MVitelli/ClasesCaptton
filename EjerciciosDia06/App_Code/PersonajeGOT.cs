using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersonajeGOT
/// </summary>
public class PersonajeGOT
{
    private string nombre;
    private string mascota;

    public PersonajeGOT(string name)
    {
        this.nombre = name;
    }

    public string Nombre
    {
        get
        {
            return this.nombre;
        }
        set
        {
            this.nombre = value;
        }

    }
    public string Mascota
    {
        get
        {
            return this.mascota;
        }
        set
        {
            this.mascota = value;
        }

    }
}