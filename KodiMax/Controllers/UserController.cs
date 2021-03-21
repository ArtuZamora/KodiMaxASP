using KodiMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodiMax.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Details()
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    string ID = Session["ID"].ToString() ;
                    return View(db.Users.Where(u => u.ID.ToString() != ID).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                using (KodiMaxEntities db = new KodiMaxEntities())
                {
                    user.Type = "employee";
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login","Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar el empleado - " + ex);
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult CreateGlobal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGlobal(UserCE user)
        {
            try
            {
                using (KodiMaxEntities db = new KodiMaxEntities())
                {
                    if (!(user.Type == "employee" && user.CompanyID == "A1B3C4")) user.Type = "client";
                    User nU = new User() ;
                    nU.Names = user.Names;
                    nU.LastNames = user.LastNames;
                    nU.Email = user.Email;
                    nU.Birthdate = user.Birthdate;
                    nU.Cellphone = user.Cellphone;
                    nU.Genre = user.Genre;
                    nU.Type = user.Type;
                    nU.Username = user.Username;
                    nU.Password = user.Password;
                    db.Users.Add(nU);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrarse - " + ex);
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Delete(int id)
        {
            using (var db = new KodiMaxEntities())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
        }
    }
}
