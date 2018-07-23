using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class SecurityLoginsLogLogic : BaseLogic<SecurityLoginsLogPoco>
    {
        public SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : base(repository)
        {

        }

        public override void Add(SecurityLoginsLogPoco[] pocos)
        {
            base.Add(pocos);
        }

        public override void Update(SecurityLoginsLogPoco[] pocos)
        {
            base.Update(pocos);
        }

        public override SecurityLoginsLogPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<SecurityLoginsLogPoco> GetAll()
        {
            return base.GetAll();
        }
    }
}
