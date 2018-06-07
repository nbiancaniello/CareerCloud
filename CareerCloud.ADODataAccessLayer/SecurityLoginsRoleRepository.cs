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
    public class SecurityLoginsRoleRepository : BaseADO, IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SecurityLoginsRolePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Security_Logins_Roles (Id, Login, Role) 
                                VALUES (@Id, @Login, @Role)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Role", poco.Role);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Security_Logins_Roles"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco
                {
                    Id = reader.GetGuid(0),
                    Login = reader.GetGuid(1),
                    Role = reader.GetGuid(2),
                    TimeStamp = (byte[])reader[3]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos;
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SecurityLoginsRolePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Security_Logins_Roles WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (SecurityLoginsRolePoco poco in items)
            {
                cmd.CommandText = @"UPDATE Security_Logins_Roles 
                                    SET Login = @Login, 
	                                    Role = @Role
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Role", poco.Role);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
