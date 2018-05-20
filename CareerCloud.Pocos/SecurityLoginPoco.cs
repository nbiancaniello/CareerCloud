﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    class SecurityLoginPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public String Login { get; set; }
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
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
