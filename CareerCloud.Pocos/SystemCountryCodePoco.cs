using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    class SystemCountryCodePoco
    {
        [Key]
        public Char[] Code { get; set; }
        public String Name { get; set; }
    }
}
