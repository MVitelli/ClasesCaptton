using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TF_Base.Models;
using WebMatrix.WebData;

namespace mvcStore.Controllers
{
    public class AccountController : Controller
    {
        private SistemaVuelosEntities bd = new SistemaVuelosEntities();
        //
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool res = WebSecurity.Login(login.UserName, login.Password, login.RememberMe);
                if (res)
                {
                    if (Roles.IsUserInRole("Cliente"))
                    {
                        return RedirectToAction("Index", "Boleto");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Vuelo");
                    }
                }
            }

            ModelState.AddModelError("", "Error al logearse");
            return View(login);
        }

        //
        // GET: /Account/Logout
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registro registro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registro.UserName, registro.Password, new { email = registro.UserEmail, dni=registro.Dni, nombre=registro.Nombre, apellido=registro.Apellido });
                    WebSecurity.Login(registro.UserName, registro.Password);
                    Roles.AddUserToRole(registro.UserName, "Cliente");
                    return RedirectToAction("ListaBoletos", "Boleto");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            return View();
        }

    }
}
