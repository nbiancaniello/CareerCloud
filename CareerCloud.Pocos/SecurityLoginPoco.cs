﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display (Name = "Username")]
        public String Login { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Column("Created_Date")]
        public DateTime Created { get; set; }
        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }
        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }
        [Column("Is_Locked")]
        public bool IsLocked { get; set; }
        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }
        [Column("Email_Address")]
        public string EmailAddress { get; set; }
        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }
        [Column("Full_Name")]
        public string FullName { get; set; }
        [Column("Force_Change_Password")]
        public bool ForceChangePassword { get; set; }
        [Column("Prefferred_Language")]
        public string PrefferredLanguage { get; set; }
        [Timestamp]
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}
