using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace TF_Base.Controllers
{
    public class VueloController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();

        //
        // GET: /Vuelo/
        [Authorize(Roles = "EmpleadoAerolinea,EmpleadoAgencia,EncargadoAerolinea")]
        public ActionResult Index()
        {
            var vuelos = db.Vuelos.Include(v => v.Conexiones);
            ViewBag.aero = new SelectList(db.Aerolineas, "AerolineaID", "infoAerolinea");
            return View(vuelos.ToList());
        }
        //
        // POST: /Vuelo/
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            var vuelos = db.Vuelos.Include(v => v.Conexiones);
            ViewBag.aero = new SelectList(db.Aerolineas, "AerolineaID", "infoAerolinea");

            if (Request["btn"] != null)
            {
                string busqueda = fm["aero"];
                if (busqueda == "")
                {
                    return View(vuelos.ToList());
                }
                return View(vuelos.Where(v => v.AerolineaID == busqueda).ToList());
            }

            return View(vuelos.ToList());

        }

        //
        // GET: /Vuelo/Details/5

        public ActionResult Details(int id = 0)
        {
            Vuelos vuelos = db.Vuelos.Find(id);
            if (vuelos == null)
            {
                return HttpNotFound();
            }
            return View(vuelos);
        }

        //
        // GET: /Vuelo/Create
        [Authorize(Roles = "EncargadoAerolinea")]
        public ActionResult Create()
        {
            int idUsuario = WebSecurity.CurrentUserId;
            Empleados empleado = db.Empleados.SingleOrDefault(e => e.idUsuario == idUsuario);
            ViewBag.ConexionID = new SelectList(db.Conexiones.Where(c => c.AerolineaID == empleado.AerolineaID), "ConexionID", "infoConexion");

            return View();
        }

        //
        // POST: /Vuelo/Create

        [HttpPost]
        [Authorize(Roles = "EncargadoAerolinea")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vuelos vuelos)
        {
            int idUsuario = WebSecurity.CurrentUserId;
            Empleados empleado = db.Empleados.SingleOrDefault(e => e.idUsuario == idUsuario);
            ViewBag.ConexionID = new SelectList(db.Conexiones.Where(c => c.AerolineaID == empleado.AerolineaID), "ConexionID", "infoConexion", vuelos.AerolineaID);
            if (ModelState.IsValid)
            {
                if (vuelos.fecha < DateTime.Now)
                {
                    ModelState.AddModelError("", "No puede ingresar fechas anteriores a hoy");
                    return View();
                }
                else
                {
                    vuelos.asientosDisponibles = vuelos.capacidad;
                    vuelos.AerolineaID = empleado.AerolineaID;
                    db.Vuelos.Add(vuelos);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(vuelos);
        }

        //
        // GET: /Vuelo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vuelos vuelos = db.Vuelos.Find(id);
            if (vuelos == null)
            {
                return HttpNotFound();
            }
            ViewBag.AerolineaID = new SelectList(db.Conexiones, "AerolineaID", "CiudadOrigen", vuelos.AerolineaID);
            return View(vuelos);
        }

        //
        // POST: /Vuelo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vuelos vuelos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vuelos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AerolineaID = new SelectList(db.Conexiones, "AerolineaID", "CiudadOrigen", vuelos.AerolineaID);
            return View(vuelos);
        }

        //
        // GET: /Vuelo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vuelos vuelos = db.Vuelos.Find(id);
            Session["ocupados"] = vuelos.capacidad - vuelos.asientosDisponibles;
            ViewBag.error = false;
            if (vuelos == null)
            {
                return HttpNotFound();
            }
            return View(vuelos);
        }

        //
        // POST: /Vuelo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelos vuelos = db.Vuelos.Find(id);
            ViewBag.error = false;
            if (vuelos.asientosDisponibles == vuelos.capacidad)
            {
                db.Vuelos.Remove(vuelos);
            }
            else
            {
                ViewBag.error = true;
            }
            
            db.SaveChanges();
            return View("Delete");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}