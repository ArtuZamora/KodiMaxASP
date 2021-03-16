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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
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

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
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
