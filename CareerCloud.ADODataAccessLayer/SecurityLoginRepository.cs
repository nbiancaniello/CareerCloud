using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int rowsEffected = 0;
            foreach (SecurityLoginPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Security_Logins (Id, Login, Password, Created_Date, Password_Update_Date, Agreement_Accepted_Date, Is_Locked, Is_Inactive, Email_Address, Phone_Number, Full_Name, Force_Change, Prefferred_Language) 
                                    VALUES (@Id, @Login, @Password, @Created_Date, @Password_Update_Date, @Agreement_Accepted_Date, @Is_Locked, @Is_Inactive, @Email_Address, @Phone_Number, @Full_Name, @Force_Change, @Prefferred_Language)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Password", poco.Password);
                cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                cmd.Parameters.AddWithValue("@Force_Change", poco.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
