using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;

namespace TF_Base.Controllers
{
    public class ClienteController : Controller
    {
        private SistemaVuelosEntities db = new SistemaVuelosEntities();

        //
        // GET: /Cliente/

        [Authorize(Roles="EmpleadoAerolinea,EmpleadoAgencia")]
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Usuario);
            return View(cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create
        [Authorize(Roles = "EmpleadoAerolinea,EmpleadoAgencia")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [Authorize(Roles = "EmpleadoAerolinea,EmpleadoAgencia")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (db.Cliente.Where(c => c.dni == cliente.dni).Count() == 0 && db.Usuario.Where(u => u.dni == cliente.dni).Count() == 0)
                {
                    db.Cliente.Add(cliente);
                }
                else
                    if (db.Cliente.Where(c => c.dni == cliente.dni).Count() == 0 && db.Usuario.Where(u => u.dni == cliente.dni).Count() != 0)
                    {
                        Usuario usuario = db.Usuario.SingleOrDefault(u => u.dni == cliente.dni);
                        cliente.idUsuario = usuario.idUsuario;
                        db.Cliente.Add(cliente);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe este cliente");
                    }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", cliente.idUsuario);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombre", cliente.idUsuario);
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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