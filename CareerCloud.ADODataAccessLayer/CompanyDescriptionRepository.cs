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
    public class CompanyDescriptionRepository : BaseADO, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Company_Descriptions (Id, Company, Language, Company_Name, Company_Description) 
                                VALUES (@Id, @Company, @Language, @CompanyName, @CompanyDescription)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@Language", poco.LanguageId);
                cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyDescription", poco.CompanyDescription);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }       
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Company_Descriptions"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                CompanyDescriptionPoco poco = new CompanyDescriptionPoco
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    LanguageId = reader.GetString(2),
                    CompanyName = reader.GetString(3),
                    CompanyDescription = reader.GetString(4),
                    TimeStamp = (byte[])reader[5]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos;
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Company_Descriptions WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (CompanyDescriptionPoco poco in items)
            {
                cmd.CommandText = @"UPDATE Company_Descriptions
                                    SET Company = @Company, 
	                                    LanguageID = @LanguageId, 
	                                    Company_Name = @CompanyName, 
	                                    Company_Description = @CompanyDescription
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Company", poco.Company);
                cmd.Parameters.AddWithValue("@LanguageId", poco.LanguageId);
                cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyDescription", poco.CompanyDescription);
                    
                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
