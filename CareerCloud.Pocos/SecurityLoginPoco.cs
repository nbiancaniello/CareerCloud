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
        public DateTime CreatedDate { get; set; }
        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdateDate { get; set; }
        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAcceptedDate { get; set; }
        [Column("Is_Locked")]
        public Boolean IsLocked { get; set; }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }
        [Column("Email_Address")]
        public String EmailAddress { get; set; }
        [Column("Phone_Number")]
        public String PhoneNumber { get; set; }
        [Column("Full_Name")]
        public String FullName { get; set; }
        [Column("Force_Change_Password")]
        public Boolean ForceChangePassword { get; set; }
        [Column("Prefferred_Language")]
        public Char?[] PrefferredLanguage { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}
