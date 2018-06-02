using System;
using System.Configuration;
using System.Data.SqlClient;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int rowsEffected = 0;
            foreach (ApplicantJobApplicationPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Applicant_Job_Educations (Id, Applicant, Job, Application_Date) 
                                    VALUES (@Id, @Applicant, @Job, @Application_Date)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);

                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<ApplicantJobApplicationPoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<ApplicantJobApplicationPoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
