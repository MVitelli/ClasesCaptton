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
        [Authorize(Roles = "EmpleadoAgencia,EmpleadoAerolinea")]
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
            ViewBag.dni = new SelectList(db.Cliente, "dni", "dni", boletos.dni);
            ViewBag.idEstado = new SelectList(db.Estado.Where(e=>e.nombreEstado!="cancelado"), "idEstado", "nombreEstado", boletos.idEstado);
            int idUsuario = WebSecurity.CurrentUserId;
            Empleados empleado = db.Empleados.SingleOrDefault(e => e.idUsuario == idUsuario);
            if (Roles.IsUserInRole("EmpleadoAerolinea"))
            {
                ViewBag.numeroVuelo = new SelectList(db.Vuelos.Where(v => v.AerolineaID == empleado.AerolineaID), "numeroVuelo", "infoVuelo", boletos.numeroVuelo);
            }
            else
            {
                ViewBag.numeroVuelo = new SelectList(db.Vuelos, "numeroVuelo", "infoVuelo", boletos.numeroVuelo);
            }
                      
            if (ModelState.IsValid)
            {
                Vuelos vueloActual = db.Vuelos.Find(boletos.numeroVuelo);

                if (vueloActual.asientosDisponibles > 0)
                {
                    db.Boletos.Add(boletos);
                    vueloActual.asientosDisponibles -= 1;
                }
                else
                {
                    ModelState.AddModelError("", "No hay lugar en el vuelo");
                    return View();
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boletos);
        }

        //
        // GET: /Boleto/Confirmar/5

        public ActionResult Confirmar(int id = 0)
        {
            Boletos boletos = db.Boletos.Find(id);
            if (boletos == null)
            {
                return HttpNotFound();
            }
            boletos.idEstado = 2; //lo paso a confirmado
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // GET: /Boleto/Cancelar/5

        public ActionResult Cancelar(int id = 0)
        {
            Boletos boletos = db.Boletos.Find(id);
            if (boletos == null)
            {
                return HttpNotFound();
            }
            boletos.idEstado = 3; //lo paso a cancelado
            Vuelos vueloActual = db.Vuelos.Find(boletos.numeroVuelo);
            vueloActual.asientosDisponibles += 1;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult ListaBoletos()
        {
            int id = WebSecurity.CurrentUserId;
            var boletos = db.Boletos.Where(b => b.Cliente.idUsuario == id && b.Vuelos.fecha >= DateTime.Now);
            //muestro todas las reservas, incluso los cancelados
            return View(boletos);
        }

        public ActionResult Historial()
        {
            int id = WebSecurity.CurrentUserId;
            var historial = db.Boletos.Where(h => h.Cliente.idUsuario == id && h.Vuelos.fecha < DateTime.Now);
            return View(historial);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}