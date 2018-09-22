using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CareerCloud.MVC.Controllers
{
    public class HomeController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Login,Password")] SecurityLoginPoco poco)
        {
            if (poco.Login == null || poco.Password == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            poco = logic.GetAll().Where(s => s.Login == poco.Login && s.Password == poco.Password).FirstOrDefault();
            if (null == poco)
            {
                return View();
            }
            return RedirectToAction("Edit/" + poco.Id, "ApplicantProfile");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}