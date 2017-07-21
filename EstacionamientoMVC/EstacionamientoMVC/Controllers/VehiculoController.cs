using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstacionamientoMVC.Models;

namespace EstacionamientoMVC.Controllers
{
    public class VehiculoController : Controller
    {
        private EstacionamientoMVCEntities db = new EstacionamientoMVCEntities();

        //
        // GET: /Vehiculo/

        public ActionResult Index()
        {
            var vehiculo = db.vehiculo.Include(v => v.tipoDeVehiculo);
            ViewBag.aut = new SelectList(db.vehiculo, "patente", "patente");

            return View(vehiculo.ToList());
        }

        //
        // POST: /Vehiculo/
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            var vehiculo = db.vehiculo.Include(v => v.tipoDeVehiculo);
            ViewBag.aut = new SelectList(db.vehiculo, "patente", "patente");

            if (Request["btn"] != null)
            {
                string busqueda = fm["aut"];
                if (busqueda == "")
                {
                    return View(db.vehiculo.ToList());
                }
                return View(db.vehiculo.Where(l => l.patente == busqueda).ToList());
            }
            else
            {
                string busqueda2 = fm["estacionados"];
                switch (busqueda2)
                {
                    case "2":
                        return View(db.vehiculo.ToList());
                    case "0":
                        return View(db.vehiculo.Where(v=>v.registros.Where(r=>r.fechaEgreso==null).Count()==0));
                    case "1":
                        return View(db.vehiculo.Where(v => v.registros.Where(r => r.fechaEgreso == null).Count() > 0));
                    
                }
            }

            return View(vehiculo.ToList());

        }


        //
        // GET: /Vehiculo/Details/5

        public ActionResult Details(string id = null)
        {
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Create

        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.tipoDeVehiculo, "idTipo", "nombre");
            return View();
        }

        //
        // POST: /Vehiculo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                vehiculo consulta = db.vehiculo.Find(vehiculo.patente);
                if (consulta != null)
                {
                    return View("PatenteDuplicada");
                }
                else
                {
                    db.vehiculo.Add(vehiculo);
                    db.SaveChanges();
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipo = new SelectList(db.tipoDeVehiculo, "idTipo", "nombre", vehiculo.idTipo);
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Edit/5

        public ActionResult Edit(string id = null)
        {
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.tipoDeVehiculo, "idTipo", "nombre", vehiculo.idTipo);
            return View(vehiculo);
        }

        //
        // POST: /Vehiculo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(db.tipoDeVehiculo, "idTipo", "nombre", vehiculo.idTipo);
            return View(vehiculo);
        }

        //
        // GET: /Vehiculo/Delete/5

        public ActionResult Delete(string id = null)
        {
            vehiculo vehiculo = db.vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //
        // POST: /Vehiculo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            vehiculo vehiculo = db.vehiculo.Find(id);
            db.vehiculo.Remove(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}