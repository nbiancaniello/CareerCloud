using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int rowsEffected = 0;
            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Job_Skills (Id, Job, Skill, Skill_Level, Importance) 
                                    VALUES (@Id, @Job, @Skill, @Skill_Level, @Importance)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                cmd.Parameters.AddWithValue("@Importance", poco.Importance);

                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
