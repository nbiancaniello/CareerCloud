using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Registration Date")]
        [Column("Registration_Date")]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Website")]
        [Column("Company_Website")]
        public string CompanyWebsite { get; set; }
        [Display(Name = "Contact Phone")]
        [Column("Contact_Phone")]
        public string ContactPhone { get; set; }
        [Display(Name = "Contact Name")]
        [Column("Contact_Name")]
        public string ContactName { get; set; }
        [Display(Name = "Logo")]
        [Column("Company_Logo")]
        public byte[] CompanyLogo { get; set; }
        [Timestamp]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }

    }
}
