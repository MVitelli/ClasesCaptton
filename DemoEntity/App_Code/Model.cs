﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Autor
{
    public Autor()
    {
        this.Libro = new HashSet<Libro>();
    }

    public int idAutor { get; set; }
    public string nombre { get; set; }
    public string nacionalidad { get; set; }

    public virtual ICollection<Libro> Libro { get; set; }

    
}

public partial class Editorial
{
    public Editorial()
    {
        this.Libro = new HashSet<Libro>();
    }

    public int idEditorial { get; set; }
    public string nombre { get; set; }
    public string ubicacion { get; set; }

    public virtual ICollection<Libro> Libro { get; set; }
}

public partial class Genero
{
    public Genero()
    {
        this.Libro = new HashSet<Libro>();
    }

    public int idGenero { get; set; }
    public string nombre { get; set; }

    public virtual ICollection<Libro> Libro { get; set; }
}

public partial class Libro
{
    public Libro()
    {
        this.Autor = new HashSet<Autor>();
        this.Genero = new HashSet<Genero>();
    }

    public string ISBN { get; set; }
    public string titulo { get; set; }
    public System.DateTime fechaDeEdicion { get; set; }
    public int idEditorial { get; set; }
    public int cantidadPaginas { get; set; }

    public virtual Editorial Editorial { get; set; }
    public virtual ICollection<Autor> Autor { get; set; }
    public virtual ICollection<Genero> Genero { get; set; }
}
