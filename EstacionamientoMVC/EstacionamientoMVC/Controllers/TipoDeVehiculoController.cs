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
    public class TipoDeVehiculoController : Controller
    {
        private EstacionamientoMVCEntities db = new EstacionamientoMVCEntities();

        //
        // GET: /TipoDeVehiculo/

        public ActionResult Index()
        {
            return View(db.tipoDeVehiculo.ToList());
        }

        //
        // GET: /TipoDeVehiculo/Details/5

        public ActionResult Details(int id = 0)
        {
            tipoDeVehiculo tipodevehiculo = db.tipoDeVehiculo.Find(id);
            if (tipodevehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipodevehiculo);
        }

        //
        // GET: /TipoDeVehiculo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoDeVehiculo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tipoDeVehiculo tipodevehiculo)
        {
            if (ModelState.IsValid)
            {
                db.tipoDeVehiculo.Add(tipodevehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodevehiculo);
        }

        //
        // GET: /TipoDeVehiculo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipoDeVehiculo tipodevehiculo = db.tipoDeVehiculo.Find(id);
            if (tipodevehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipodevehiculo);
        }

        //
        // POST: /TipoDeVehiculo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tipoDeVehiculo tipodevehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodevehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodevehiculo);
        }

        //
        // GET: /TipoDeVehiculo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipoDeVehiculo tipodevehiculo = db.tipoDeVehiculo.Find(id);
            if (tipodevehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipodevehiculo);
        }

        //
        // POST: /TipoDeVehiculo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoDeVehiculo tipodevehiculo = db.tipoDeVehiculo.Find(id);
            db.tipoDeVehiculo.Remove(tipodevehiculo);
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