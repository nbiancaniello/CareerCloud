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
    public class CompanyJobRepository : BaseADO, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Jobs (Id, Company, Profile_Created, Is_Inactive, Is_Company_Hidden) 
                                VALUES (@Id, @Company, @Profile_Created, @IsInactive, @IsCompanyHidden)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@IsCompanyHidden", poco.IsCompanyHidden);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[1001];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Company_Jobs"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                CompanyJobPoco poco = new CompanyJobPoco
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    ProfileCreated = reader.GetDateTime(2),
                    IsInactive= reader.GetBoolean(3),
                    IsCompanyHidden= reader.GetBoolean(4),
                    TimeStamp = (byte[])reader[5]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Company_Jobs WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyJobPoco poco in items)
            {
                cmd.CommandText = @"UPDATE Company_Jobs 
                                    SET Company = @Company, 
	                                    Profile_Created = @ProfileCreated, 
	                                    Is_Inactive = @IsInactive, 
	                                    Is_Company_Hidden = @IsCompanyHidden 
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@ProfileCreated", poco.ProfileCreated);
                cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@IsCompanyHidden", poco.IsCompanyHidden);
                    
                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
