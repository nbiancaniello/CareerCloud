using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO Security_Logins (Id, Login, Password, Created_Date, Password_Update_Date, Agreement_Accepted_Date, Is_Locked, Is_Inactive, Email_Address, Phone_Number, Full_Name, Force_Change_Password, Prefferred_Language) 
                                VALUES (@Id, @Login, @Password, @Created, @PasswordUpdate, @AgreementAccepted, @IsLocked, @IsInactive, @EmailAddress, @PhoneNumber, @FullName, @ForceChangePassword, @PrefferredLanguage)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created", poco.Created);
                    cmd.Parameters.AddWithValue("@PasswordUpdate", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AgreementAccepted", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLocked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddress", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", poco.FullName);
                    cmd.Parameters.AddWithValue("@ForceChangePassword", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PrefferredLanguage", poco.PrefferredLanguage);

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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1000];
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = "SELECT * FROM Security_Logins"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco
                    {
                        Id = reader.GetGuid(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Created = reader.GetDateTime(3),
                        PasswordUpdate = (DateTime?)(reader.IsDBNull(4) ? null : reader[4]),
                        AgreementAccepted = (DateTime?)(reader.IsDBNull(5) ? null : reader[5]),
                        IsLocked = reader.GetBoolean(6),
                        IsInactive = reader.GetBoolean(7),
                        EmailAddress = reader.GetString(8),
                        PhoneNumber = (reader.IsDBNull(9) ? null : reader.GetString(9)),
                        FullName = reader.GetString(10),
                        ForceChangePassword = reader.GetBoolean(11),
                        PrefferredLanguage = (reader.IsDBNull(12) ? null : reader.GetString(12)),
                        TimeStamp = (byte[])reader[13]
                    };

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Security_Logins WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Security_Logins 
                                    SET Login = @Login, 
                                    Password = @Password, 
                                    Created_Date = @Created, 
                                    Password_Update_Date = @PasswordUpdate, 
                                    Agreement_Accepted_Date = @AgreementAccepted, 
                                    Is_Locked = @IsLocked, 
                                    Is_Inactive = @IsInactive, 
                                    Email_Address = @EmailAddress, 
                                    Phone_Number = @PhoneNumber, 
                                    Full_Name = @FullName, 
                                    Force_Change_Password = @ForceChangePassword, 
                                    Prefferred_Language = @PrefferredLanguage
                                    WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created", poco.Created);
                    cmd.Parameters.AddWithValue("@PasswordUpdate", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AgreementAccepted", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLocked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddress", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", poco.FullName);
                    cmd.Parameters.AddWithValue("@ForceChangePassword", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PrefferredLanguage", poco.PrefferredLanguage);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
