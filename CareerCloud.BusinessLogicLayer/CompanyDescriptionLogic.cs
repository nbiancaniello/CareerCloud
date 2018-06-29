using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {

        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
       
            foreach(CompanyDescriptionPoco poco in pocos)
            {
                if (poco.CompanyDescription.Length < 3)
                {
                    exceptions.Add(new ValidationException(107,
                        $"Company Description must be greater than 2 characters - {poco.Id}"));
                }
                if (poco.CompanyName.Length < 3)
                {
                    exceptions.Add(new ValidationException(106,
                        $"Company Name must be greater than 2 characters - {poco.Id}"));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
