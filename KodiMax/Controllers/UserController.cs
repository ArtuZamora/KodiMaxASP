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
