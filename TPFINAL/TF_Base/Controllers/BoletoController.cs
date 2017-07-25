using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace TF_Base.Controllers
{
    public class BoletoController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();

        //
        // GET: /Boleto/
        [Authorize(Roles="EmpleadoAgencia,EmpleadoAerolinea")]
        public ActionResult Index()
        {
            if (Roles.IsUserInRole("EmpleadoAgencia"))
            {
                var boletos = db.Boletos.Include(b => b.Cliente).Include(b => b.Estado).Include(b => b.Vuelos);
                return View(boletos.ToList());
            }
            else
            {
                int idUsuario = WebSecurity.CurrentUserId;
                Empleados empleadoAerolineaActual = db.Empleados.SingleOrDefault(e => e.idUsuario == idUsuario);
                var boletos = db.Boletos.Where(b => b.Vuelos.AerolineaID == empleadoAerolineaActual.AerolineaID);
                return View(boletos.ToList());

            }
        }

        //
        // GET: /Boleto/Details/5

        public ActionResult Details(int id = 0)
        {
            Boletos boletos = db.Boletos.Find(id);
            if (boletos == null)
            {
                return HttpNotFound();
            }
            return View(boletos);
        }

        //
        // GET: /Boleto/Create

        [Authorize(Roles = "EmpleadoAerolinea,EmpleadoAgencia")]
        public ActionResult Create()
        {
            int idUsuario = WebSecurity.CurrentUserId;
            Empleados empleado = db.Empleados.SingleOrDefault(e => e.idUsuario == idUsuario);

            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni");
            ViewBag.idEstado = new SelectList(db.Estado.Where(e => e.nombreEstado != "cancelado"), "idEstado", "nombreEstado");
            if (Roles.IsUserInRole("EmpleadoAerolinea"))
            {
                ViewBag.numeroVuelo = new SelectList(db.Vuelos.Where(v => v.AerolineaID == empleado.AerolineaID), "numeroVuelo", "infoVuelo");
            }
            else
            {
                ViewBag.numeroVuelo = new SelectList(db.Vuelos, "numeroVuelo", "infoVuelo");
            }


            return View();
        }

        //
        // POST: /Boleto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Boletos boletos)
        {
            if (ModelState.IsValid)
            {
                db.Boletos.Add(boletos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni", boletos.dni);
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombreEstado", boletos.idEstado);
            ViewBag.numeroVuelo = new SelectList(db.Vuelos, "numeroVuelo", "infoVuelo", boletos.numeroVuelo);
            return View(boletos);
        }

        //
        // GET: /Boleto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Boletos boletos = db.Boletos.Find(id);
            if (boletos == null)
            {
                return HttpNotFound();
            }
            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni", boletos.dni);
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombreEstado", boletos.idEstado);
            ViewBag.numeroVuelo = new SelectList(db.Vuelos, "numeroVuelo", "AerolineaID", boletos.numeroVuelo);
            return View(boletos);
        }

        //
        // POST: /Boleto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Boletos boletos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boletos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni", boletos.dni);
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "nombreEstado", boletos.idEstado);
            ViewBag.numeroVuelo = new SelectList(db.Vuelos, "numeroVuelo", "AerolineaID", boletos.numeroVuelo);
            return View(boletos);
        }

        //
        // GET: /Boleto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Boletos boletos = db.Boletos.Find(id);
            if (boletos == null)
            {
                return HttpNotFound();
            }
            return View(boletos);
        }

        //
        // POST: /Boleto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boletos boletos = db.Boletos.Find(id);
            db.Boletos.Remove(boletos);
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