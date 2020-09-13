using Diplomado_MVC_UASD_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_UASD_Login.Controllers
{
    public class RegistrosController : Controller
    {
        UsersDataDataContext db = new UsersDataDataContext();

        // GET: Registros
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Registros/Details/5
        public ActionResult Details(int id)
        {
            User usr = db.Users.FirstOrDefault(x => x.IdUser == id);
            if (usr == null)
            {
                return HttpNotFound();
            }

            return View(usr);
        }

        // GET: Registros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registros/Create
        [HttpPost]
        public ActionResult Create(SignIn datos)
        {

            if (ModelState.IsValid)
            {
                if (datos.Signin() == false)
                {
                    ViewBag.Message = "El Usuario o Email Ya esta Registrado";
                    return View("Create", datos);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Create");
            }

        }


        // GET: Registros/Edit/5
        public ActionResult Edit(int id)
        {

            User usr = db.Users.FirstOrDefault(x => x.IdUser == id);
            if (usr == null)
            {
                return HttpNotFound();
            }
            return View(usr);
        }

        // POST: Registros/Edit/5

        //public ActionResult Edit(int id, FormCollection collection)
        [HttpPost]
        public ActionResult Edit(User usr)
        {
            if (ModelState.IsValid)
            {
                User usr2 = db.Users.FirstOrDefault(x => x.IdUser == usr.IdUser);

                if (usr2 != null)
                {
                    //usr2.IdUser = 
                    usr2.Name = usr.Name;
                    usr2.LastName = usr.LastName;
                    usr2.UserName = usr.UserName;
                    usr2.Password = usr.Password;
                    usr2.Email = usr.Email;
                    db.SubmitChanges();
                }
            }
            return RedirectToAction("Index");
        }


        // GET: Registros/Delete/5
        public ActionResult Delete(int id)
        {
            User usr = db.Users.FirstOrDefault(x => x.IdUser == id);
            if (usr == null)
            {
                return HttpNotFound();
            }
            return View(usr);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfrim(int id)
        {
            User usr2 = db.Users.FirstOrDefault(x => x.IdUser == id);
            if (usr2!=null)
            {
                db.Users.DeleteOnSubmit(usr2);
                db.SubmitChanges();
            } 
            return RedirectToAction("Index");
        }
    }
}
