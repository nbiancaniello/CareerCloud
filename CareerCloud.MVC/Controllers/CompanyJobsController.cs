using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.MVC.Models;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyJobsController : Controller
    {
        // GET: CompanyJobs
        public ActionResult Index()
        {
            var pocos = getJobs((Guid)System.Web.HttpContext.Current.Session["companyJobsId"]);
            if (pocos == null)
            {
                return HttpNotFound();
            }

            return View(pocos);
        }

        // GET: CompanyJobs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobs companyJobs = getJob(id);
            if (companyJobs == null)
            {
                return HttpNotFound();
            }
            return View(companyJobs);
        }

        // GET: CompanyJobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,JobName,JobDescription")] CompanyJobs companyJobs)
        {
            if (ModelState.IsValid)
            {
                var companyJobsLogic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
                Guid jobId = Guid.NewGuid();
                companyJobsLogic.Add(new CompanyJobPoco[] { new CompanyJobPoco
                                                            {
                                                                Id = jobId,
                                                                Company = (Guid)System.Web.HttpContext.Current.Session["companyJobsId"],
                                                                ProfileCreated = DateTime.Now,
                                                                IsInactive = false,
                                                                IsCompanyHidden = false
                                                            }
                                        });
                var companyJobsDescriptionLogic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>());
                Guid jobsDescriptionId = Guid.NewGuid();
                companyJobsDescriptionLogic.Add(new CompanyJobDescriptionPoco[] { new CompanyJobDescriptionPoco
                                                            {
                                                                Id = jobsDescriptionId,
                                                                Job = jobId,
                                                                JobName = companyJobs.JobName,
                                                                JobDescriptions = companyJobs.JobDescription
                                                            }
                                        });
                return RedirectToAction("Index");
            }

            return View(companyJobs);
        }

        // GET: CompanyJobs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobs companyJobs = getJob(id);
            if (companyJobs == null)
            {
                return HttpNotFound();
            }
            return View(companyJobs);
        }

        public List<CompanyJobs> getJobs(Guid? id)
        {
            List<CompanyJobs> pocos = new List<CompanyJobs>();
            using (SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = @"select cj.Id, cj.Company, Job_Name, Job_Descriptions
                                    from Company_Jobs cj
                                    join Company_Jobs_Descriptions cjd on cj.Id = cjd.Job
                                    where cj.Company = '" + id.ToString() + "'; "
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobs poco = new CompanyJobs
                    {
                        Id = reader.GetGuid(0),
                        Company = reader.GetGuid(1),
                        JobName = reader.GetString(2),
                        JobDescription = reader.GetString(3)
                    };

                    pocos.Add(poco);
                }
                _connection.Close();
            }
            return pocos;
        }

        public CompanyJobs getJob(Guid? id)
        {
            CompanyJobs poco = null;
            using (SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = @"select cj.Id, cj.Company, Job_Name, Job_Descriptions
                                    from Company_Jobs cj
                                    join Company_Jobs_Descriptions cjd on cj.Id = cjd.Job
                                    where cj.Id = '" + id.ToString() + "'; "
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    poco = new CompanyJobs
                    {
                        Id = reader.GetGuid(0),
                        Company = reader.GetGuid(1),
                        JobName = reader.GetString(2),
                        JobDescription = reader.GetString(3)
                    };

                }
                _connection.Close();
            }
            return poco;
        }

    }
}
