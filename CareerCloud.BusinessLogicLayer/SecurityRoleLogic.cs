using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityRoleLogic : BaseLogic<SecurityRolePoco>
    {
        public SecurityRoleLogic(IDataRepository<SecurityRolePoco> repository) : base(repository)
        {

        }

        public override void Add(SecurityRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SecurityRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override SecurityRolePoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<SecurityRolePoco> GetAll()
        {
            return base.GetAll();
        }

        protected override void Verify(SecurityRolePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SecurityRolePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Role))
                {
                    exceptions.Add(new ValidationException(800,
                        $"Role cannot be empty. - {poco.Id}"));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
