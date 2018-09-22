using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantProfileController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();
                
        // GET: ApplicantProfile/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco poco;
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            poco = logic.GetAll().Where(s => s.Login == id).FirstOrDefault();
            if (poco == null)
            {
                return HttpNotFound();
            }
            id = poco.Id;
            ViewBag.Login = new SelectList(db.SecurityLogins, "Id", "Login", poco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCodes, "Code", "Name", poco.Country);
            return View(poco);
        }

        // POST: ApplicantProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode,TimeStamp")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantProfilePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.SecurityLogins, "Id", "Login", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
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
