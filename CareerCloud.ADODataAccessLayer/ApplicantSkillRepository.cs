using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    class ApplicantSkillRepository : IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int rowsEffected = 0;
            foreach (ApplicantSkillPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO APPLICANT_EDUCATIONS () VALUES (@,@,@)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantSkillPoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantSkillPoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantSkillPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantSkillPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
