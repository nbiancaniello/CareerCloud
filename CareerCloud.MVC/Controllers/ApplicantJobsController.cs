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
    public class ApplicantJobsController : Controller
    {
        // GET: ApplicantJobs
        public ActionResult Index()
        {
            var pocos = getJobsApplied();
            if (pocos == null)
            {
                return HttpNotFound();
            }
            
            return View(pocos);
        }

        public ActionResult Apply()
        {
            return RedirectToAction("Index","JobsLists");
        }

        public List<ApplicantJobs> getJobsApplied()
        {
            List<ApplicantJobs> pocos = new List<ApplicantJobs>();
            using (SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = @"select cd.Company_Name, aja.Application_Date, cjd.Job_Name, cjd.Job_Descriptions
                                    from Applicant_Job_Applications aja
                                    join Company_Jobs_Descriptions cjd on aja.Job = cjd.Job
                                    join Company_Jobs cj on cjd.Job = cj.Id
                                    join Company_Descriptions cd on cj.Company = cd.Company
                                    where aja.Applicant = '"+ System.Web.HttpContext.Current.Session["ApplicantProfileId"].ToString() + "';"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantJobs poco = new ApplicantJobs
                    {
                        CompanyName = reader.GetString(0),
                        ApplicationDate = reader.GetDateTime(1),
                        JobName = reader.GetString(2),
                        JobDescription = reader.GetString(3)
                    };

                    pocos.Add(poco);
                }
                _connection.Close();
            }
            return pocos;
        }
        
    }
}
