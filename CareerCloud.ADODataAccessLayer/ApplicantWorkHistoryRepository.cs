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
    public class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (ApplicantWorkHistoryPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Applicant_Work_History (Id, Applicant, Company_Name, Country_Code, Location, Job_Title, Job_Description, Start_Month, Start_Year, End_Month, End_Year)
                                VALUES (@Id, @Applicant, @CompanyName, @CountryCode, @Location, @JobTitle, @JobDescription, @StartMonth, @StartYear, @EndMonth, @EndYear)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
                cmd.Parameters.AddWithValue("@CountryCode", poco.CountryCode);
                cmd.Parameters.AddWithValue("@Location", poco.Location);
                cmd.Parameters.AddWithValue("@JobTitle", poco.JobTitle);
                cmd.Parameters.AddWithValue("@JobDescription", poco.JobDescription);
                cmd.Parameters.AddWithValue("@StartMonth", poco.StartMonth);
                cmd.Parameters.AddWithValue("@StartYear", poco.StartYear);
                cmd.Parameters.AddWithValue("@EndMonth", poco.EndMonth);
                cmd.Parameters.AddWithValue("@EndYear", poco.EndYear);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        { 
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Applicant_Work_History"
            };

            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
                
            int position = 0;
            while (reader.Read())
            {
                ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    CompanyName = reader.GetString(2),
                    CountryCode = reader.GetString(3),
                    Location = reader.GetString(4),
                    JobTitle = reader.GetString(5),
                    JobDescription = reader.GetString(6),
                    StartMonth = reader.GetInt16(7),
                    StartYear = reader.GetInt32(8),
                    EndMonth = reader.GetInt16(9),
                    EndYear = reader.GetInt32(10),
                    TimeStamp = (byte[])reader[11]
                };

                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (ApplicantWorkHistoryPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM Applicant_Work_History WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (ApplicantWorkHistoryPoco poco in items)
            {
                cmd.CommandText = @"UPDATE Applicant_Work_History
                                    SET Applicant = @Applicant, 
	                                    Company_Name = @CompanyName, 
	                                    Country_Code = @CountryCode, 
	                                    Location = @Location, 
	                                    Job_Title = @JobTitle, 
	                                    Job_Description = @JobDescription,
                                        Start_Month = @StartMonth,
                                        Start_Year = @StartYear,
                                        End_Month = @EndMonth,
                                        End_Year = @EndYear
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
                cmd.Parameters.AddWithValue("@CountryCode", poco.CountryCode);
                cmd.Parameters.AddWithValue("@Location", poco.Location);
                cmd.Parameters.AddWithValue("@JobTitle", poco.JobTitle);
                cmd.Parameters.AddWithValue("@JobDescription", poco.JobDescription);
                cmd.Parameters.AddWithValue("@StartMonth", poco.StartMonth);
                cmd.Parameters.AddWithValue("@StartYear", poco.StartYear);
                cmd.Parameters.AddWithValue("@EndMonth", poco.EndMonth);
                cmd.Parameters.AddWithValue("@EndYear", poco.EndYear);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
