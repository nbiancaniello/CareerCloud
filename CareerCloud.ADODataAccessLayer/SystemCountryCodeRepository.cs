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
    public class SystemCountryCodeRepository : BaseADO, IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SystemCountryCodePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO System_Country_Codes (Code, Name) 
                                VALUES (@Code, @Name)";
                cmd.Parameters.AddWithValue("@Code", poco.Code);
                cmd.Parameters.AddWithValue("@Name", poco.Name);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM System_Country_Codes"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                SystemCountryCodePoco poco = new SystemCountryCodePoco
                {
                    Code = reader.GetString(0),
                    Name = reader.GetString(1)
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos;
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (SystemCountryCodePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM System_Country_Codes WHERE Code = @Code";
                cmd.Parameters.AddWithValue("@Code", poco.Code);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SystemCountryCodePoco poco in items)
            {
                cmd.CommandText = @"UPDATE System_Country_Codes
                                    SET Name = @Name
                                    WHERE Code = @Code";
                cmd.Parameters.AddWithValue("@Code", poco.Code);
                cmd.Parameters.AddWithValue("@Name", poco.Name);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
