using KodiMax.Models;
using System.Linq;
using System.Web.Mvc;

namespace KodiMax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            if(Session["ID"] == null) return View();
            else
            {
                switch (Session["Type"].ToString().Trim())
                {
                    case "admin":
                        return RedirectToAction("AdminDashBoard");
                    case "employee":
                        return RedirectToAction("EmployeeDashBoard");
                    case "client":
                        return RedirectToAction("ClientDashBoard");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (KodiMaxEntities db = new KodiMaxEntities())
                {
                    var obj = db.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Type"] = obj.Type.ToString();
                        Session["Names"] = obj.Names.ToString();
                        Session["LastNames"] = obj.LastNames.ToString();
                        Session["Birthdate"] = obj.Birthdate.ToString();
                        Session["Cellphone"] = obj.Cellphone.ToString();
                        Session["Email"] = obj.Email.ToString();
                        Session["Genre"] = obj.Genre.ToString();
                        switch(obj.Type.ToString().Trim())
                        {
                            case "admin":
                                return RedirectToAction("AdminDashBoard");
                            case "employee":
                                return RedirectToAction("EmployeeDashBoard");
                            case "client":
                                return RedirectToAction("ClientDashBoard");
                        }
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult ClientDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult AdminDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult EmployeeDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}