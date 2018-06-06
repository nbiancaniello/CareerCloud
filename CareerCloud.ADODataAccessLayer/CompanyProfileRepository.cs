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
    public class CompanyProfileRepository : BaseADO, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (CompanyProfilePoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO Company_Profiles (Id, Registration_Date, Company_Website, Contact_Phone, Contact_Name, Company_Logo)
                                    VALUES (@Id, @RegistrationDate, @CompanyWebsite, @ContactPhone, @ContactName, @CompanyLogo)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@RegistrationDate", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsite", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@ContactPhone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@ContactName", poco.ContactName);
                    cmd.Parameters.AddWithValue("@CompanyLogo", poco.CompanyLogo);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1000];
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT * FROM Company_Profiles"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco
                    {
                        Id = reader.GetGuid(0),
                        RegistrationDate = reader.GetDateTime(1),
                        CompanyWebsite = reader.GetString(2),
                        ContactPhone= reader.GetString(3),
                        ContactName = reader.GetString(4),
                        CompanyLogo = (byte[])reader[5],
                        TimeStamp = (byte[])reader[6]
                    };

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (CompanyProfilePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Company_Profiles WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (CompanyProfilePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Company_Profiles 
                                        SET Registration_Date = @RegistrationDate, 
	                                        Company_Website = @CompanyWebsite, 
	                                        Contact_Phone = @ContactPhone, 
	                                        Contact_Name = @ContactName, 
	                                        Company_Logo= @CompanyLogo
                                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@RegistrationDate", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsite", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@ContactPhone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@ContactName", poco.ContactName);
                    cmd.Parameters.AddWithValue("@CompanyLogo", poco.CompanyLogo);
                    
                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
