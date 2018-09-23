using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class ApplicantJobs
    {
        //public Guid Id { get; set; }
        //public Guid Applicant { get; set; }
        //public Guid Job { get; set; }
        public string CompanyName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
    }
}