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
        public ActionResult Index()
        {
            int id = WebSecurity.CurrentUserId;
            if (Roles.IsUserInRole("Cliente"))
            {
                List<Boletos> listaBoletos = db.Boletos.Where(b => b.Cliente.idUsuario == id).ToList();
                foreach (var item in listaBoletos)
                {
                    if (item.idEstado == 1 && item.Vuelos.fecha < DateTime.Now) //pregunto si el boleto está en reservado y ya pasó la fecha del vuelo
                    {
                        item.idEstado = 3; //lo paso a cancelado porque ya pasó esa fecha
                    }
                }
                db.SaveChanges();
                return RedirectToAction("ListaBoletos", "Boleto");
            }
            else
            {
                Empleados empleado = db.Empleados.SingleOrDefault(e => e.idUsuario == id);

                string fechaIngreso = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string[] roles = Roles.GetRolesForUser();
                string log = "";
                if (Roles.IsUserInRole("EmpleadoAgencia"))
                {
                    log = "[" + fechaIngreso + "] " + "Inicio Sesión - " + roles.First() + " " + empleado.Usuario.apellido + " Agencia";
                }
                else
                {
                    log = "[" + fechaIngreso + "] " + "Inicio Sesión - " + roles.First() + " " + empleado.Usuario.apellido + " " + empleado.Aerolineas.Nombre;

                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Alumno\Desktop\Log.txt", true))
                {
                    file.WriteLine(log);
                }

                var vuelos = db.Vuelos.Include(v => v.Conexiones);
                vuelos = vuelos.Where(v => v.fecha >= DateTime.Now);
                ViewBag.aero = new SelectList(db.Aerolineas, "AerolineaID", "infoAerolinea");
                return View(vuelos.ToList());
            }

        }
        //
        // POST: /Vuelo/
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            var vuelos = db.Vuelos.Include(v => v.Conexiones);
            vuelos = vuelos.Where(v => v.fecha >= DateTime.Now);
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
            ViewBag.ConexionID = new SelectList(db.Conexiones.Where(c => c.AerolineaID == empleado.AerolineaID), "ConexionID", "infoConexionConAerolinea");

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
            ViewBag.ConexionID = new SelectList(db.Conexiones.Where(c => c.AerolineaID == empleado.AerolineaID), "ConexionID", "infoConexionConAerolinea", vuelos.AerolineaID);

            if (ModelState.IsValid)
            {
                if (vuelos.fecha < DateTime.Now)
                {
                    ModelState.AddModelError("", "No puede ingresar fechas anteriores a hoy");
                    return View();
                }
                else
                {
                    List<Vuelos> busqueda = db.Vuelos.Where(v => v.ConexionID == vuelos.ConexionID && v.fecha == vuelos.fecha).ToList();
                    //me fijo si ya hay un vuelo con la misma fecha y la misma conexion
                    if (busqueda.Count() > 0)
                    {
                        ModelState.AddModelError("", "Ya existe un vuelo con esta fecha y esta conexion");
                        return View();
                    }
                    else
                    {
                        vuelos.asientosDisponibles = vuelos.capacidad;
                        vuelos.AerolineaID = empleado.AerolineaID;
                        db.Vuelos.Add(vuelos);
                    }

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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}