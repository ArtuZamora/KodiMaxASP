using KodiMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodiMax.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Details()
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    return View(db.Movies.ToList());
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
        public ActionResult Create(Movie movie)
        {
            try
            {
                using (KodiMaxEntities db = new KodiMaxEntities())
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar la pelicula - " + ex);
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                using (var db = new KodiMaxEntities())
                {
                    Movie movieR = db.Movies.Find(movie.ID);
                    movieR.Duration = movie.Duration;
                    movieR.Type = movie.Type;
                    movieR.Image = movie.Image;
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
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult MoviesList()
        {
            using (var db = new KodiMaxEntities())
            {
                return PartialView(db.Movies.ToList());
            }
        }
    }
}
