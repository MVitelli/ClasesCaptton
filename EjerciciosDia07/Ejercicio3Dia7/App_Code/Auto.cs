using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Auto
/// </summary>
public class Auto
{
    public string patente;
    public DateTime horarioEntrada;
    public string dueño;

    public Auto(string patente, string dueño)
    {
        this.patente = patente;
        this.horarioEntrada = DateTime.Now;
        this.dueño = dueño;
    }
    public override bool Equals(object obj)
    {
        return ((obj!=null)&&(((Auto)obj).patente==this.patente));
    }
    
}