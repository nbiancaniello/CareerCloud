using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
        {
                
        }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(ApplicantProfilePoco poco in pocos)
            {
                if (poco.CurrentSalary < 0)
                {
                    exceptions.Add(new ValidationException(111,
                        $"CurrentSalary cannot be negative - {poco.Id}"));
                }
                if (poco.CurrentRate < 0)
                {
                    exceptions.Add(new ValidationException(112,
                        $"CurrentRate cannot be negative - {poco.Id}"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
