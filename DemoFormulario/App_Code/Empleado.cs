using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empleado
/// </summary>
public class Empleado
{
    public string nombre, apellido, area;
    public int dni;
    public Empleado(string name, string lastname, string area, int dni)
    {
        this.apellido = lastname;
        this.nombre = name;
        this.dni = dni;
        this.area = area;
    }
}