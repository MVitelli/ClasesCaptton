using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class LibroController : Controller
    {
        private LibrosEntities db = new LibrosEntities();

        //
        // GET: /Libro/

        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Editorial);
            ViewBag.edi = new SelectList(db.Editorial, "idEditorial", "nombre");
            ViewBag.aut = new SelectList(db.Autor, "idAutor", "nombre");
            ViewBag.gen = new SelectList(db.Genero, "idGenero", "nombre");

            return View(libro.ToList());
        }
        //
        // POST: /Libro/
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            ViewBag.edi = new SelectList(db.Editorial, "idEditorial", "nombre");
            ViewBag.aut = new SelectList(db.Autor, "idAutor", "nombre");
            ViewBag.gen = new SelectList(db.Genero, "idGenero", "nombre");
            if (Request["btn"] != null)
            {
                string busqueda = fm["edi"];
                if (busqueda == "")
                {
                    return View(db.Libro.ToList());
                }
                int id = int.Parse(busqueda);
                return View(db.Libro.Where(l => l.idEditorial == id).ToList());
            }
            else
                if (Request["btn2"] != null)
                {
                    string busqueda2 = fm["aut"];
                    if (busqueda2 == "")
                    {
                        return View(db.Libro.ToList());
                    }
                    int id2 = int.Parse(busqueda2);
                    Autor autor = db.Autor.Find(id2);
                    return View(autor.Libro.ToList());
                }
                else
                {
                    string busqueda3 = fm["gen"];
                    if (busqueda3 == "")
                    {
                        return View(db.Libro.ToList());
                    }
                    int id3 = int.Parse(busqueda3);
                    Genero genero = db.Genero.Find(id3);
                    return View(genero.Libro.ToList());
                }
        }

        //
        // GET: /Libro/Details/5

        public ActionResult Details(string id = null)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // GET: /Libro/Create

        public ActionResult Create()
        {
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre");
            return View();
        }

        //
        // POST: /Libro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro libro, FormCollection fm) //fm es una coleccion del formulario
        {
            if (ModelState.IsValid)
            {
                string nombre = Request["aut"];
                Autor consultaAutor = null;
                Autor autor = new Autor();
                consultaAutor = db.Autor.SingleOrDefault(a => a.nombre == nombre);
                if (consultaAutor == null)
                {
                    autor.nombre = nombre;
                    db.Autor.Add(autor);
                }
                else
                {
                    autor = consultaAutor;
                }
                libro.Autor.Add(autor);

                string nombreGenero = fm["gen"]; //es lo mismo que hacer request
                Genero consultaGen = new Genero();
                Genero genero = new Genero();
                consultaGen = db.Genero.SingleOrDefault(g => g.nombre == nombreGenero);
                if (consultaGen == null)
                {
                    genero.nombre = nombreGenero;
                    db.Genero.Add(genero);
                }
                else
                {
                    genero = consultaGen;
                }
                libro.Genero.Add(genero);
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre", libro.idEditorial);
            return View(libro);
        }

        //
        // GET: /Libro/Edit/5

        public ActionResult Edit(string id = null)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre", libro.idEditorial);
            return View(libro);
        }

        //
        // POST: /Libro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEditorial = new SelectList(db.Editorial, "idEditorial", "nombre", libro.idEditorial);
            return View(libro);
        }

        //
        // GET: /Libro/Delete/5

        public ActionResult Delete(string id = null)
        {
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // POST: /Libro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Libro libro = db.Libro.Find(id);
            libro.Genero.Clear();
            libro.Autor.Clear();
            db.Libro.Remove(libro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Quitar(int id, string idLibro)
        {
            Autor autor = db.Autor.Find(id);
            Libro libro = db.Libro.Find(idLibro);

            libro.Autor.Remove(autor);
            db.SaveChanges();
            return View("Index");
            

        }
    }
}