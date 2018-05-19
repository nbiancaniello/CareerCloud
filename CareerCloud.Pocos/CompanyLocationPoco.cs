using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }
        [Column("Country_Code")]
        public Char[] CountryCode { get; set; }
        [Column("State_Province_Code")]
        public Char?[] StateProvinceCode { get; set; }
        [Column("Street_Address")]
        public String StreetAddress { get; set; }
        [Column("City_Town")]
        public String CityTown { get; set; }
        [Column("Zip_Postal_Code")]
        public Char?[] ZipPostalCode { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}
