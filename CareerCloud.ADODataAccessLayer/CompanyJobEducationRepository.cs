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
    public class CompanyJobEducationRepository : BaseADO, IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobEducationPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Job_Educations (Id, Job, Major, Importance) 
                                VALUES (@Id, @Job, @Major, @Importance)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Major", poco.Major);
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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Company_Job_Educations"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                CompanyJobEducationPoco poco = new CompanyJobEducationPoco
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    Major = reader.GetString(2),
                    Importance= reader.GetInt16(3),
                    TimeStamp = (byte[])reader[4]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos;
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobEducationPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Company_Job_Educations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobEducationPoco poco in items)
            {
                cmd.CommandText = @"UPDATE Company_Job_Educations 
                                    SET Job = @Job, 
	                                    Major = @Major, 
	                                    Importance = @Importance, 
	                                WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Job);
                cmd.Parameters.AddWithValue("@Major", poco.Major);
                cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                    
                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
