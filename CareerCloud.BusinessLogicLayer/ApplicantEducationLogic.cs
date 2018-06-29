using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
                
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(ApplicantEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major.Trim()))
                {
                    exceptions.Add(new ValidationException(107,
                        $"Cannot be empty or less than 3 characters - {poco.Id}"));
                }
                else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, 
                        $"Cannot be empty or less than 3 characters - {poco.Id}"));
                }
                if (poco.StartDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108,
                        $"Cannot be greater than today - {poco.Id}"));
                }
                if (poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109,
                        $"CompletionDate cannot be earlier than StartDate - {poco.Id}"));
                }

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
