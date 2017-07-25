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
    public class RegistroController : Controller
    {
        private EstacionamientoMVCEntities db = new EstacionamientoMVCEntities();

        //
        // GET: /Registro/

        public ActionResult Index()
        {
            List<registros> registros = db.registros.Include(r => r.parcela).Include(r => r.vehiculo).ToList();


            return View(registros.ToList());
        }

        //
        // POST: /Registro/
        [HttpPost]
        public ActionResult Index(FormCollection fm)
        {
            var registros = db.registros.Include(r => r.parcela).Include(r => r.vehiculo);

            if (fm["resumen"] == "")
            {
                Session["total"] = '-';
                return View(registros.ToList());
            }

            DateTime calendario = DateTime.Parse(fm["resumen"]);

            registros = db.registros.Where(r => r.fechaEgreso.Value.Year == calendario.Year && r.fechaEgreso.Value.Month == calendario.Month && r.fechaEgreso.Value.Day == calendario.Day);

            double total = 0;
            foreach (var item in registros)
            {
                total += item.monto.Value;
            }

            Session["total"] = total;

            return View(registros.ToList());

        }

        //
        // GET: /Registro/Details/5

        public ActionResult Details(string id = null)
        {
            registros registros = db.registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        //
        // GET: /Registro/Create

        public ActionResult Create()
        {
            List<vehiculo> listaVehiculos = db.vehiculo.Where(v => v.registros.Where(r => r.fechaEgreso == null).Count() == 0).ToList();

            ViewBag.idParcela = new SelectList(db.parcela.Where(p => p.estado == false), "idParcela", "idParcela");
            ViewBag.patente = new SelectList(listaVehiculos, "patente", "patente");
            return View();
        }

        //
        // POST: /Registro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(registros registros)
        {
            if (ModelState.IsValid)
            {
                registros.fechaIngreso = DateTime.Now;
                parcela parcela = db.parcela.Find(registros.idParcela);
                parcela.estado = true;
                db.registros.Add(registros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<vehiculo> listaVehiculos = db.vehiculo.Where(v => v.registros.Where(r => r.fechaEgreso == null).Count() == 0).ToList();
            ViewBag.idParcela = new SelectList(db.parcela.Where(p => p.estado == false), "idParcela", "idParcela", registros.idParcela);
            ViewBag.patente = new SelectList(listaVehiculos, "patente", "patente", registros.patente);
            return View(registros);
        }

        //
        // GET: /Registro/Edit/5

        public ActionResult Edit(string id = null)
        {
            DateTime fecha = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            registros registros = db.registros.SingleOrDefault(r => r.fechaIngreso == fecha);
            if (registros == null)
            {
                return HttpNotFound();
            }
            ViewBag.idParcela = new SelectList(db.parcela, "idParcela", "idParcela", registros.idParcela);
            ViewBag.patente = new SelectList(db.vehiculo, "patente", "patente", registros.patente);
            return View(registros);
        }

        //
        // POST: /Registro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(registros registros, FormCollection fm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idParcela = new SelectList(db.parcela, "idParcela", "idParcela", registros.idParcela);
            ViewBag.patente = new SelectList(db.vehiculo, "patente", "patente", registros.patente);
            return View(registros);
        }

        //
        // GET: /Registro/Delete/5

        public ActionResult Delete(string id = null)
        {
            DateTime fecha = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            registros registros = db.registros.SingleOrDefault(r => r.fechaIngreso == fecha);
            registros.fechaEgreso = DateTime.Now;

            TimeSpan time = registros.fechaEgreso.Value - registros.fechaIngreso;
            int diferencia = (int)time.TotalHours;
            Session["horas"] = diferencia;
            registros.monto = diferencia * registros.vehiculo.tipoDeVehiculo.tarifa;
            Session["tarifa"] = registros.monto;

            int cantVecesEstacionoEnElMes = db.registros.Where(r => r.patente == registros.patente && r.fechaIngreso.Month == registros.fechaIngreso.Month).Count();

            double monto = (double)Session["tarifa"];

            if (cantVecesEstacionoEnElMes >= 10 && (registros.fechaIngreso.DayOfWeek == DayOfWeek.Saturday || registros.fechaIngreso.DayOfWeek == DayOfWeek.Sunday))
            {
                Session["tarifa"] = monto * 0.75;
            }
            else
            {
                if (cantVecesEstacionoEnElMes < 10 && (registros.fechaIngreso.DayOfWeek == DayOfWeek.Saturday || registros.fechaIngreso.DayOfWeek == DayOfWeek.Sunday))
                {
                    Session["tarifa"] = monto * 0.90;
                }
                else
                    if (cantVecesEstacionoEnElMes > 10)
                    {
                        Session["tarifa"] = monto * 0.85;
                    }
                    else
                    {
                        Session["tarifa"] = monto;
                    }
            }
            registros.monto = (double)Session["tarifa"];

            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        //
        // POST: /Registro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DateTime fecha = DateTime.ParseExact(id, "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);

            registros registros = db.registros.SingleOrDefault(r => r.fechaIngreso == fecha);
            registros.fechaEgreso = DateTime.Now;

            TimeSpan time = registros.fechaEgreso.Value - registros.fechaIngreso;
            int diferencia = (int)time.TotalHours;
            Session["horas"] = diferencia;
            registros.monto = diferencia * registros.vehiculo.tipoDeVehiculo.tarifa;
            Session["tarifa"] = registros.monto;

            int cantVecesEstacionoEnElMes = db.registros.Where(r => r.patente == registros.patente && r.fechaIngreso.Month == registros.fechaIngreso.Month).Count();

            if (cantVecesEstacionoEnElMes >= 10 && (registros.fechaIngreso.DayOfWeek == DayOfWeek.Saturday || registros.fechaIngreso.DayOfWeek == DayOfWeek.Sunday))
            {
                double monto = (double)Session["tarifa"];
                Session["tarifa"] = monto * 0.75;
            }
            else
            {
                if (cantVecesEstacionoEnElMes < 10 && (registros.fechaIngreso.DayOfWeek == DayOfWeek.Saturday || registros.fechaIngreso.DayOfWeek == DayOfWeek.Sunday))
                {
                    double monto = (double)Session["tarifa"];
                    Session["tarifa"] = monto * 0.90;
                }
                else
                {
                    double monto = (double)Session["tarifa"];
                    Session["tarifa"] = monto * 0.85;
                }
            }
            registros.monto = (double)Session["tarifa"];

            parcela parcelaAHabilitar = db.parcela.Find(registros.idParcela);
            parcelaAHabilitar.estado = false;

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