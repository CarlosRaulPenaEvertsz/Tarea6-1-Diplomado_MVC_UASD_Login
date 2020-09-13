using Diplomado_MVC_UASD_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_UASD_Login.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();

    
        
        public ActionResult Index()
        {
    
            return View();
        }

        


        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Borrar()
        {
            return View();
        }

        public ActionResult Detalles()
        {
            return View();
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        [AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View();   
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.login() == true)
                {
                    session.setSession("userName", datos.Username);
                    ViewBag.User = session.getSession("userName");
                    return RedirectToAction("Users", "User");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(SignIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Signin() == false)
                {
                    ViewBag.Message = "El Usuario o Email Ya esta Registrado";
                    return View("SignIn", datos);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("SignIn");
            }
        }
    }
}