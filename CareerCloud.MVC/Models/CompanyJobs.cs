using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class CompanyJobs
    {
        public Guid Id { get; set; }
        public Guid Company { get; set; }
        [Required (ErrorMessage ="Job Name is required.")]
        [Display(Name = "Job Name")]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Job Description is required.")]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
    }
}