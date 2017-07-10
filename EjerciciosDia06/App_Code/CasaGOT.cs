using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CasaGOT
/// </summary>
public class CasaGOT
{
    string nombre;
    string lema;

    public CasaGOT(string name)
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
    public string Lema
    {
        get
        {
            return this.lema;
        }
        set
        {
            this.lema = value;
        }

    }
}