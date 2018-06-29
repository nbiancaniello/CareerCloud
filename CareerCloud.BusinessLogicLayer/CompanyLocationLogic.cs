using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {

        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyLocationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CountryCode.Trim()))
                {
                    exceptions.Add(new ValidationException(500,
                        $"Country Code cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Province.Trim()))
                {
                    exceptions.Add(new ValidationException(501,
                        $"Province cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Street.Trim()))
                {
                    exceptions.Add(new ValidationException(502,
                        $"Street cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.City.Trim()))
                {
                    exceptions.Add(new ValidationException(503,
                        $"City cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.PostalCode.Trim()))
                {
                    exceptions.Add(new ValidationException(504,
                        $"Postal Code cannot be empty"));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
