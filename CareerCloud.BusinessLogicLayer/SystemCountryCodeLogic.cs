using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class SystemCountryCodeLogic
    {
        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code.Trim()))
                {
                    exceptions.Add(new ValidationException(900, 
                        $"Code cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name.Trim()))
                {
                    exceptions.Add(new ValidationException(901,
                        $"Name cannot be empty"));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
