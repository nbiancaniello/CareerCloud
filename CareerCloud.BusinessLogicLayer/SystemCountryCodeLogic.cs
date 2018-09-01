﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
            _repository = repository;
        }

        public SystemCountryCodePoco Get(string id)
        {
            IQueryable<SystemCountryCodePoco> pocos = _repository.GetAll().AsQueryable();
            return pocos.FirstOrDefault(t => t.Code == id);
        }

        public List<SystemCountryCodePoco> GetAll()
        {
            IList<SystemCountryCodePoco> pocos = _repository.GetAll();
            return pocos.ToList();
        }

        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, 
                        $"Code cannot be empty."));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901,
                        $"Name cannot be empty."));
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
