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
    public class SecurityRoleRepository : BaseADO, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SecurityRolePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Security_Roles (Id, Role, Is_Inactive) 
                                VALUES (@Id, @Role, @IsInactive)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Role", poco.Role);
                cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }   
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Security_Roles"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int position = 0;
            while (reader.Read())
            {
                SecurityRolePoco poco = new SecurityRolePoco
                {
                    Id = reader.GetGuid(0),
                    Role = reader.GetString(1),
                    IsInactive = reader.GetBoolean(2)
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SecurityRolePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Security_Roles WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
                int rowsEffected = 0;
            foreach (SecurityRolePoco poco in items)
            {
                cmd.CommandText = @"UPDATE Security_Roles 
                                    SET Role = @Role, 
	                                    Is_Inactive = @IsInactive 
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Role", poco.Role);
                cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
