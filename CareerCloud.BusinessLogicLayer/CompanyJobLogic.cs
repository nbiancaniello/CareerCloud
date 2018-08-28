using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
    {
        public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
        {

        }

        public override void Add(CompanyJobPoco[] pocos)
        {
            base.Add(pocos);
        }

        public override void Update(CompanyJobPoco[] pocos)
        {
            base.Update(pocos);
        }

        public override CompanyJobPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyJobPoco> GetAll()
        {
            return base.GetAll();
        }
    }
}
