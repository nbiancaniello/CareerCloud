using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : BaseADO, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO Applicant_Job_Applications (Id, Applicant, Job, Application_Date) 
                                VALUES (@Id, @Applicant, @Job, @ApplicationDate)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", poco.ApplicationDate);

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

        public System.Collections.Generic.IList<ApplicantJobApplicationPoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1000];
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = _connection,
                    CommandText = "SELECT * FROM Applicant_Job_Applications"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco
                    {
                        Id = reader.GetGuid(0),
                        Applicant = reader.GetGuid(1),
                        Job = reader.GetGuid(2),
                        ApplicationDate = reader.GetDateTime(3),
                        TimeStamp = (byte[])reader[4]
                    };

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public System.Collections.Generic.IList<ApplicantJobApplicationPoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Job_Applications WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = _connection
                };
                int rowsEffected = 0;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Job_Applications 
                                    SET Applicant = @Applicant, 
	                                    Job = @Job, 
	                                    Application_Date = @ApplicationDate
                                    WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", poco.ApplicationDate);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
