using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseADO, IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO Applicant_Educations (Id, Applicant, Major, Certificate_Diploma, Start_Date, Completion_Date, Completion_Percent) 
                                        VALUES (@Id,@Applicant, @Major, @CertificateDiploma, @StartDate, @CompletionDate, @CompletionPercent)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@CertificateDiploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@StartDate", poco.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", poco.CompletionPercent);

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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "SELECT * FROM Applicant_Educations"
                };

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco
                    {
                        Id = reader.GetGuid(0),
                        Applicant = reader.GetGuid(1),
                        Major = reader.GetString(2),
                        CertificateDiploma= reader.GetString(3),
                        StartDate = (DateTime?)(reader.IsDBNull(4) ? null : reader[4]),
                        CompletionDate = (DateTime?)(reader.IsDBNull(5) ? null : reader[5]),
                        CompletionPercent = (byte?)(reader.IsDBNull(6) ? null : reader[6]),
                        TimeStamp = (byte[])reader[7]
                    };

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Educations WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                int rowsEffected = 0;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Educations 
                                        SET Applicant = @Applicant, 
	                                        Major = @Major, 
	                                        Certificate_Diploma = @CertificateDiploma, 
	                                        Start_Date = @StartDate, 
	                                        Completion_Date = @CompletionDate, 
	                                        Completion_Percent = @CompletionPercent 
                                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@CertificateDiploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@StartDate", poco.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", poco.CompletionPercent);

                    _connection.Open();
                    rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
