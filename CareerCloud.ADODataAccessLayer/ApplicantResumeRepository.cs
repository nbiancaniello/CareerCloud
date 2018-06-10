using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (ApplicantResumePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Applicant_Resumes (Id, Applicant, Resume, Last_Updated)
                                VALUES (@Id, @Applicant, @Resume, @LastUpdated)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                cmd.Parameters.AddWithValue("@LastUpdated", poco.LastUpdated);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1000];
            SqlCommand cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = "SELECT * FROM Applicant_Resumes"
            };
            int position = 0;
            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ApplicantResumePoco poco = new ApplicantResumePoco
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Resume = reader.GetString(2),
                    LastUpdated = (DateTime?)(reader.IsDBNull(3) ? null : reader[3])
                };
                pocos[position] = poco;
                position++;
            }
            _connection.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantResumePoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantResumePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantResumePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;

            foreach (ApplicantResumePoco poco in items)
            {
                cmd.CommandText = "DELETE FROM Applicant_Resumes WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);

                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {

            SqlCommand cmd = new SqlCommand()
            {
                Connection = _connection
            };
            int rowsEffected = 0;
            foreach (ApplicantResumePoco poco in items)
            {
                cmd.CommandText = @"UPDATE Applicant_Resumes
                                    SET Applicant = @Applicant, 
                                        Resume = @Resume,
                                        Last_Updated = @LastUpdated
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                cmd.Parameters.AddWithValue("@LastUpdated", poco.LastUpdated);
                _connection.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
