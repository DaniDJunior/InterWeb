using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterWeb.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            ViewBag.User = string.Empty;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authentication(string user, string password)
        {
            if ((user == "acesso@acesso.io") && (password == "/Acess0)"))
            {
                Session["ProdutoCredito.WebUIMVC.UserLog"] = "acesso@acesso.io";
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.User = user;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logoff()
        {
            Session["ProdutoCredito.WebUIMVC.UserLog"] = null;
            ViewBag.User = string.Empty;
            return RedirectToAction("Index", "Login");
        }
	}
}