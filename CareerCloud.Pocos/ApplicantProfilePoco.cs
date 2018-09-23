using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        [Display(Name = "Current Salary")]
        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }
        [Display(Name = "Current Rate")]
        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }
        public string Currency { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        [Column("Country_Code")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Province is required.")]
        [Column("State_Province_Code")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Street is required.")]
        [Column("Street_Address")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required.")]
        [Column("City_Town")]
        public string City { get; set; }
        [Required(ErrorMessage = "Postal Code is required.")]
        [Display(Name = "Postal Code")]
        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }
        [Timestamp]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
    }
}
