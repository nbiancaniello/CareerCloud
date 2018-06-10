using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : BaseADO, IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Job_Skills (Id, Job, Skill, Skill_Level, Importance) 
                                VALUES (@Id, @Job, @Skill, @SkillLevel, @Importance)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                cmd.Parameters.AddWithValue("@SkillLevel", poco.SkillLevel);
                cmd.Parameters.AddWithValue("@Importance", poco.Importance);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }            
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[5001];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Company_Job_Skills"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                CompanyJobSkillPoco poco = new CompanyJobSkillPoco
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    Skill = reader.GetString(2),
                    SkillLevel= reader.GetString(3),
                    Importance = reader.GetInt32(4),
                    TimeStamp = (byte[])reader[5]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Company_Job_Skills WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobSkillPoco poco in items)
            {
                cmd.CommandText = @"UPDATE Company_Job_Skills 
                                    SET Job = @Job, 
	                                    Skill = @Skill, 
	                                    Skill_Level= @SkillLevel, 
	                                    Importance = @Importance
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                cmd.Parameters.AddWithValue("@SkillLevel", poco.SkillLevel);
                cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                    
                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
