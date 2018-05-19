using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    class ApplicantProfile : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }
        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }
        public Char?[] Currency { get; set; }
        [Column("Country_Code")]
        public Char?[] CountryCode { get; set; }
        [Column("State_Province_Code")]
        public Char?[] StateProvinceCode { get; set; }
        [Column("Street_Addres")]
        public String StreetAddress { get; set; }
        [Column("City_Town")]
        public String CityTown { get; set; }
        [Column("Zip_Postal_Code")]
        public Char?[] ZipPostalCode { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}
