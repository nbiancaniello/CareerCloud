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
    public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            int rowsEffected = 0;
            foreach (SecurityLoginsLogPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Security_Logins_Log (Id, Login, Source_IP, Logon_Date, Is_Succesful) 
                                    VALUES (@Id, @Login, @SourceIP, @LogonDate, @IsSuccesful)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@SourceIP", poco.SourceIP);
                cmd.Parameters.AddWithValue("@LogonDate", poco.LogonDate);
                cmd.Parameters.AddWithValue("@IsSuccesful", poco.IsSuccesful);

                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1000];
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT * FROM Security_Logins_Log"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco
                    {
                        Id = reader.GetGuid(0),
                        Login = reader.GetGuid(1),
                        SourceIP = reader.GetString(2),
                        LogonDate = reader.GetDateTime(3),
                        IsSuccesful = reader.GetBoolean(4)
                    };

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Security_Logins_Log WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Security_Logins_Log 
                                        SET Login = @Login, 
                                            Source_IP = @SourceIP, 
                                            Logon_Date = @LogonDate, 
                                            Is_Succesful = @IsSuccessful 
                                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@SourceIP", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@LogonDate", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@IsSuccesful", poco.IsSuccesful);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
