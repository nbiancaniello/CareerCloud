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
    public class CompanyJobDescriptionRepository : BaseADO, IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobDescriptionPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Jobs_Descriptions (Id, Job, Job_Name, Job_Descriptions)
                                VALUES (@Id, @Job, @JobName, @JobDescriptions)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@JobName", poco.JobName);
                cmd.Parameters.AddWithValue("@JobDescriptions", poco.JobDescriptions);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[1001];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Company_Jobs_Descriptions"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco
                {
                    Id = reader.GetGuid(0),
                    Job = reader.GetGuid(1),
                    JobName = reader.GetString(2),
                    JobDescriptions = reader.GetString(3),
                    TimeStamp = (byte[])reader[4]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobDescriptionPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Company_Jobs_Descriptions WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobDescriptionPoco poco in items)
            {
                cmd.CommandText = @"UPDATE Company_Jobs_Descriptions 
                                    SET Job = @Job, 
	                                    Job_Name = @JobName, 
	                                    Job_Descriptions = @JobDescriptions 
	                                WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@JobName", poco.JobName);
                cmd.Parameters.AddWithValue("@JobDescriptions", poco.JobDescriptions);
                    
                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
