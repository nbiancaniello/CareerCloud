using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {

        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyProfilePoco poco in pocos)
            {
                // CORRECT VALIDATION WITH SUBSTRING
                if (!poco.CompanyWebsite.Contains(".ca") ||
                    !poco.CompanyWebsite.Contains(".com") ||
                    !poco.CompanyWebsite.Contains(".biz"))
                {
                    exceptions.Add(new ValidationException(600,
                        $"Valid websites must end with the following extensions – '.ca', '.com', '.biz'"));
                }
                string[] phoneComponents = poco.ContactPhone.Split('-');
                if (phoneComponents.Length < 3)
                {
                    exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                }
                else
                {
                    if (phoneComponents[0].Length < 3)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                    }
                    else if (phoneComponents[1].Length < 3)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                    }
                    else if (phoneComponents[2].Length < 4)
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for SecurityLogin {poco.Id} is not in the required format."));
                    }
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
