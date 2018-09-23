using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System.Linq;
using System.Net;
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

            // Get user credentials, later profile information
            var securityLoginLogic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            poco = securityLoginLogic.GetAll().Where(s => s.Login.ToLower() == poco.Login.ToLower() && s.Password == poco.Password).FirstOrDefault();
            var applicantProfileLogic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            var applicant = applicantProfileLogic.GetAll().Where(s => s.Login == poco.Id).FirstOrDefault();

            if (null == poco)
            {
                return View();
            }

            // Only Administrator is allowed to view and manage Companies
            if (poco.Login.ToLower() == "administrator")
            {
                return RedirectToAction("Index", "CompanyDescription");
            }
            System.Web.HttpContext.Current.Session["ApplicantProfileId"] = applicant.Id;
            return RedirectToAction("Edit", "ApplicantProfile");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}