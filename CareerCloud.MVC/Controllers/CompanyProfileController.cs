using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyProfileController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();
        private EFGenericRepository<CompanyProfilePoco> repository = new EFGenericRepository<CompanyProfilePoco>();

        // GET: CompanyProfile
        public ActionResult Index()
        {
            return View(db.CompanyProfiles.ToList());
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            CompanyProfileLogic profileLogic = new CompanyProfileLogic(repository);
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                companyProfilePoco.RegistrationDate = DateTime.Now;
                try
                {
                    db.CompanyProfiles.Add(companyProfilePoco);
                    db.SaveChanges();
                } catch(DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                System.Web.HttpContext.Current.Session["companyProfileId"] = companyProfilePoco.Id;
                return RedirectToAction("Create","CompanyDescription");
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo,TimeStamp")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyProfilePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "CompanyDescription");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            // delete also description

            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            db.CompanyProfiles.Remove(companyProfilePoco);
            db.SaveChanges();
            return RedirectToAction("Index","CompanyDescription");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
