using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
    {
        public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : base(repository)
        {

        }

        protected override void Verify(CompanyJobSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(CompanyJobSkillPoco poco in pocos)
            {
                if(poco.Importance < 0)
                {
                    exceptions.Add(new ValidationException(400,
                        $"Importance cannot be less than 0"));
                }
            }

            if(exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
