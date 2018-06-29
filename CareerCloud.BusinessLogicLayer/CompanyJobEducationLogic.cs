using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {

        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(CompanyJobEducationPoco poco in pocos)
            {
                if(poco.Major.Length < 2)
                {
                    exceptions.Add(new ValidationException(200,
                        $"Major must be at least 2 characters - {poco.Id}"));
                }
                if (poco.Importance < 0)
                {
                    exceptions.Add(new ValidationException(201,
                        $"Importance cannot be less than 0 - {poco.Id}"));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
