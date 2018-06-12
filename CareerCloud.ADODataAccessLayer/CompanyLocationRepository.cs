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
    public class CompanyLocationRepository : BaseADO, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (CompanyLocationPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO Company_Locations (Id, Company, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code) 
                                VALUES (@Id, @Company, @CountryCode, @Province, @Street, @City, @PostalCode)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@CountryCode", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Province", poco.Province);
                    cmd.Parameters.AddWithValue("@Street", poco.Street);
                    cmd.Parameters.AddWithValue("@City", poco.City);
                    cmd.Parameters.AddWithValue("@PostalCode", poco.PostalCode);

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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[1000];
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = "SELECT * FROM Company_Locations"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    CompanyLocationPoco poco = new CompanyLocationPoco
                    {
                        Id = reader.GetGuid(0),
                        Company = reader.GetGuid(1),
                        CountryCode = reader.GetString(2),
                        Province = reader.GetString(3),
                        Street = reader.GetString(4),
                        City = (reader.IsDBNull(5) ? null : reader.GetString(5)),
                        PostalCode = (reader.IsDBNull(6) ? null : reader.GetString(6)),
                        TimeStamp = (byte[])reader[7]
                    };

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (CompanyLocationPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Company_Locations WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (CompanyLocationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Company_Locations 
                                    SET Company = @Company, 
	                                    Country_Code = @CountryCode, 
	                                    State_Province_Code = @Province, 
	                                    Street_Address = @Street, 
	                                    City_Town = @City, 
	                                    Zip_Postal_Code = @PostalCode 
                                    WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@CountryCode", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Province", poco.Province);
                    cmd.Parameters.AddWithValue("@Street", poco.Street);
                    cmd.Parameters.AddWithValue("@City", poco.City);
                    cmd.Parameters.AddWithValue("@PostalCode", poco.PostalCode);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
