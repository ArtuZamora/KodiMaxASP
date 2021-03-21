using KodiMax.Models;
using System.Linq;
using System.Web.Mvc;

namespace KodiMax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            if (UserSession.user != null) ReSession();
            if (UserSession.user == null) return View();
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
                        UserSession.user = obj;
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
            if (UserSession.user != null)
            {
                if (Session["Type"].ToString().Trim() == "client") return View();
                else return RedirectToAction("Login");
            }
            else return RedirectToAction("Login");
        }
        public ActionResult AdminDashBoard()
        {
            if (UserSession.user != null)
            {
                if(Session["Type"].ToString().Trim() == "admin") return View();
                else return RedirectToAction("Login");
            }
            else return RedirectToAction("Login");
        }
        public ActionResult EmployeeDashBoard()
        {
            if (UserSession.user != null)
            {
                if (Session["Type"].ToString().Trim() == "employee") return View();
                else return RedirectToAction("Login");
            }
            else return RedirectToAction("Login");
        }
        public ActionResult LoginGlobal()
        {
            return View();
        }
        public void ReSession()
        {
            Session["ID"] = UserSession.user.ID.ToString();
            Session["Username"] = UserSession.user.Username.ToString();
            Session["Type"] = UserSession.user.Type.ToString();
            Session["Names"] = UserSession.user.Names.ToString();
            Session["LastNames"] = UserSession.user.LastNames.ToString();
            Session["Birthdate"] = UserSession.user.Birthdate.ToString();
            Session["Cellphone"] = UserSession.user.Cellphone.ToString();
            Session["Email"] = UserSession.user.Email.ToString();
            Session["Genre"] = UserSession.user.Genre.ToString();
        }
        public ActionResult UnSession()
        {
            UserSession.user = null;
            return RedirectToAction("Login");
        }
    }
}