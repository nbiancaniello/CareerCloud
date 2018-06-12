using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : BaseADO, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO Applicant_Profiles (Id, Login, Current_Salary, Current_Rate, Currency, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code) 
                                VALUES (@Id, @Login, @CurrentSalary, @CurrentRate, @Currency, @Country, @Province, @Street, @City, @PostalCode)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@CurrentSalary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@CurrentRate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country", poco.Country);
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

        public IList<ApplicantProfilePoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = @"SELECT * FROM Applicant_Profiles"
                };
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco
                    {
                        Id = reader.GetGuid(0),
                        Login = reader.GetGuid(1),
                        CurrentSalary = (Decimal?)(reader.IsDBNull(2) ? null : reader[2]),
                        CurrentRate = (Decimal?)(reader.IsDBNull(3) ? null : reader[3]),
                        Currency = reader.GetString(4),
                        Country = reader.GetString(5),
                        Province = reader.GetString(6),
                        Street = reader.GetString(7),
                        City = reader.GetString(8),
                        PostalCode = reader.GetString(9),
                        TimeStamp = (byte[])(reader.IsDBNull(10) ? null : reader[10])
                    };
                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Profiles WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Profiles 
                                    SET Login = @Login,
                                        Current_Salary = @CurrentSalary,
                                        Current_Rate = @CurrentRate,
                                        Currency = @Currency,
                                        Country_Code = @Country,
                                        State_Province_Code = @Province,
                                        Street_Address = @Street,
                                        City_Town = @City,
                                        Zip_Postal_Code = @PostalCode
                                    WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@CurrentSalary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@CurrentRate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country", poco.Country);
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
