using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TESTEs2it.Models;

namespace TESTEs2it.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autorizado(TESTEs2it.Models.login LoginModel)
        {
            using (TesteS2ITEntities db = new TesteS2ITEntities())
            {
                var usuarioDetalhe = db.login.Where(x => x.Usuario == LoginModel.Usuario && x.Senha == LoginModel.Senha).FirstOrDefault();
                if (usuarioDetalhe == null)
                {
                    LoginModel.LoginErrorMessage = "Usuário ou Senha Incorretos!";
                    return View("Index", LoginModel);
                }
                else
                {
                    Session["UserID"] = usuarioDetalhe.UserID;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
