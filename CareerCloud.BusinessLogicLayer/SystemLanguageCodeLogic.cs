using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class SystemLanguageCodeLogic
    {
        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID.Trim()))
                {
                    exceptions.Add(new ValidationException(1000,
                        $"Language ID cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name.Trim()))
                {
                    exceptions.Add(new ValidationException(1001,
                        $"Name cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.NativeName.Trim()))
                {
                    exceptions.Add(new ValidationException(1002,
                        $"Native Name cannot be empty"));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
