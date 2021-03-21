using KodiMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodiMax.Controllers
{
    public class CandyController : Controller
    {
        public ActionResult Details()
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    return View(db.Candies.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DetailsClient()
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    return View(db.Candies.ToList());
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
        public ActionResult Create(Candy candy)
        {
            try
            {
                using (KodiMaxEntities db = new KodiMaxEntities())
                {
                    db.Candies.Add(candy);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar el caramelo - " + ex);
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Candy candy)
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    Candy candyR = db.Candies.Find(candy.ID);
                    candyR.Price = candy.Price;
                    candyR.Type = candy.Type;
                    candyR.Image = candy.Image;
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Home");
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new KodiMaxEntities())
            {
                Candy candy = db.Candies.Find(id);
                db.Candies.Remove(candy);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult CandiesList()
        {
            using (var db = new KodiMaxEntities())
            {
                return PartialView(db.Candies.ToList());
            }
        }
        public ActionResult BuyCandy()
        {
            return View();
        }
    }
}
