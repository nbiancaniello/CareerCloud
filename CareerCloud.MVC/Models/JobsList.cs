using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class JobsList
    {
        public Guid Id { get; set;  } // JobId
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Job Name")]
        public string JobName { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
    }
}