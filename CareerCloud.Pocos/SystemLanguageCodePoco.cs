using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    class SystemLanguageCodePoco
    {
        [Key]
        public Char[] LanguageId { get; set; }
        public String Name { get; set; }
        public String NativeName { get; set; }
    }
}
