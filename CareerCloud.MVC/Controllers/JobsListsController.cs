using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.MVC.Models;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class JobsListsController : Controller
    {
        // GET: JobsLists
        public ActionResult Index()
        {
            return View(getJobsList());
        }

        public ActionResult Apply(Guid? Id)
        {
            var applicantJobsLogic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>());
            Guid ApplicantJobId = Guid.NewGuid();
            applicantJobsLogic.Add(new ApplicantJobApplicationPoco[] { new ApplicantJobApplicationPoco
                                                            {
                                                                Id = ApplicantJobId,
                                                                Applicant = (Guid)System.Web.HttpContext.Current.Session["ApplicantProfileId"],
                                                                Job = (Guid)Id,
                                                                ApplicationDate = DateTime.Now
                                                            }
                                        });
            return RedirectToAction("Index", "ApplicantJobs");
        }

        public List<JobsList> getJobsList()
        {
            List<JobsList> pocos = new List<JobsList>();
            using (SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = @"select cjd.Job, cd.Company_Name, cjd.Job_Name, cjd.Job_Descriptions
                                    from dbo.Company_Jobs_Descriptions cjd
                                    join dbo.Company_Jobs cj on cj.id = cjd.Job
                                    join dbo.Company_Descriptions cd on cj.Company = cd.Company
                                    where cj.Id not in (select job from Applicant_Job_Applications where Applicant = '" + System.Web.HttpContext.Current.Session["ApplicantProfileId"].ToString() + "');"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobsList poco = new JobsList
                    {
                        Id = reader.GetGuid(0),
                        CompanyName = reader.GetString(1),
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
